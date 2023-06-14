using webapi.Infrastructure.Dtos;

namespace webapi.Services;

public interface IAnswerService
{
    public Task<int> AddAnswerAsync(AnswerDto answer);

    public Task DeleteAnswerByIdAsync(int id);

    public Task<AnswerDto?> GetAnswerByIdAsync(int id);

    public Task<List<AnswerDto>?> GetAnswerDtosAsync(IReadOnlyCollection<int> answerIds);
}
