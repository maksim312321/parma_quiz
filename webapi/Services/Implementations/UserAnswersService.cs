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
        return (await _repository.QueryAsync<int>(
            sql: SqlFiles.AddNewUserAnswer,
            param: new
            {
                userAnswer.UserAnswerText,
                userAnswer.AnswerId,
                userAnswer.UserId
            }
            )).FirstOrDefault();
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
            AnswerId = a.AnswerId
        }).ToList();
    }
}
