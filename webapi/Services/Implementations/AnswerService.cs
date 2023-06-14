using System.Data.SqlTypes;
using webapi.Infrastructure;
using webapi.Infrastructure.DatabaseUtils;
using webapi.Infrastructure.Dtos;
using webapi.Infrastructure.Models;

namespace webapi.Services.Implementations;

public class AnswerService : IAnswerService
{
    private readonly IRepository _repository; 
    public AnswerService(IRepository repository) 
    { 
        _repository = repository;
    }
    public async Task<int> AddAnswerAsync(AnswerDto answer)
    {
        ArgumentNullException.ThrowIfNull(answer);
        return (await _repository.QueryAsync<int>(
            sql: SqlFiles.AddNewAnswer,
            param: new
            {
                AnswerText = answer.Text
            })).FirstOrDefault();
    }

    public Task DeleteAnswerByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<AnswerDto?> GetAnswerByIdAsync(int id)
    {
        var answerModel = (await _repository.QueryAsync<AnswerModel>(
            sql: SqlFiles.GetAnswerByIds,
            param: new
            {
                AnswerIds = id
            })).FirstOrDefault();
        if (answerModel is null)
            return null;
        return new AnswerDto
        {
            Id = answerModel.AnswerId,
            Text = answerModel.AnswerText,
        };
    }

    public async Task<List<AnswerDto>?> GetAnswerDtosAsync(IReadOnlyCollection<int> answerIds)
    {
        var answerModels = (await _repository.QueryAsync<AnswerModel>(
            sql: SqlFiles.GetAnswerByIds,
            param: new
            {
                AnswerIds = answerIds
            }));
        if (answerModels is null)
            return null;
        return answerModels.Select(m => new AnswerDto
        {
            Id = m.AnswerId,
            Text = m.AnswerText
        }).ToList();
    }
}
