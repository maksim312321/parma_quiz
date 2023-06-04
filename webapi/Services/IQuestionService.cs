using webapi.Infrastructure.Dtos;
using webapi.Infrastructure.Models;

namespace webapi.Services;

public interface IQuestionService
{
    public Task<QuestionDto> GetQuestionByIdAsync(int questionId);

  //  public Task<List<QuestionDto>> GetAllQuestionsAsync();

    public Task AddQuestionAsync(QuestionDto question);
}
