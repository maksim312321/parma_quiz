using webapi.Infrastructure.Dtos;

namespace webapi.Services;

public interface IQuestionService
{
    public Task<QuestionDto?> GetQuestionByIdAsync(int questionId);

    public Task<List<QuestionDto>?> GetAllQuestionsAsync();

    public Task<int> AddQuestionAsync(QuestionDto question);

    public Task DeleteQuestionById(int questionId);
}
