using webapi.Infrastructure;
using webapi.Infrastructure.DatabaseUtils;
using webapi.Infrastructure.Dtos;
using webapi.Infrastructure.Models;

namespace webapi.Services.Implementations;

public class UserAnswersService : IUserAnswersService
{
    private readonly IRepository _repository;
    public UserAnswersService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> AddUserAnswerAsync(UserAnswerDto userAnswer)
    {
        var existedUserAnswer = (await _repository.QueryAsync<UserAnswerModel>(
            sql: SqlFiles.GetUserAnswerByQuestionId,
            param: new
            {
                userAnswer.QuestionId
            })).FirstOrDefault();
        if (existedUserAnswer is not null) 
        { 
            return (await _repository.QueryAsync<int>(
            sql: SqlFiles.UpdateUserAnswer,
            param: new
            {
                userAnswer.UserAnswerText,
                userAnswer.AnswerId,
                userAnswer.IsCorrect,
                existedUserAnswer.UserAnswerId
            }
            )).FirstOrDefault();
        }
        return (await _repository.QueryAsync<int>(
            sql: SqlFiles.AddNewUserAnswer,
            param: new
            {
                userAnswer.UserAnswerText,
                userAnswer.AnswerId,
                userAnswer.UserId,
                userAnswer.IsCorrect
            }
            )).FirstOrDefault();
    }

    public async Task CheckTheUserAnswerAsync(CheckUserAnswerDto dto)
    {
        var existedUserAnswer = (await _repository.QueryAsync<UserAnswerModel>(
            sql: SqlFiles.GetUserAnswerById,
            param: new
            {
                dto.UserAnswerId
            })).FirstOrDefault();
        if (existedUserAnswer is null)
            return;
        await _repository.ExecuteAsync(
            sql: SqlFiles.UpdateUserAnswer,
            param: new
            {
                dto.UserAnswerId,
                dto.IsCorrect,
                existedUserAnswer.UserAnswerText,
                existedUserAnswer.AnswerId
            });
    }

    public async Task<List<UserAnswerDto>?> GetAllUserAnswersByUserIdAsync(int userId)
    {
        var userAnswersModels = await _repository.QueryAsync<UserAnswerModel>(
            sql: SqlFiles.GetAllUserAnswersByUserId,
            param: new
            {
                UserId = userId
            });
        if (userAnswersModels is null || !userAnswersModels.Any())
            return null;
        return userAnswersModels.Select(a => new UserAnswerDto
        {
            UserAnswerText = a.UserAnswerText,
            UserAnswerId = a.UserAnswerId,
            AnswerId = a.AnswerId,
            UserId = a.UserId,
            IsCorrect = a.IsCorrect,
            QuestionId = a.QuestionId
        }).ToList();
    }
}
