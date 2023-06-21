using webapi.Infrastructure;
using webapi.Infrastructure.DatabaseUtils;
using webapi.Infrastructure.Dtos;
using webapi.Infrastructure.Models;

namespace webapi.Services.Implementations;

public class QuestionService : IQuestionService
{
    private readonly IRepository _repository;

    private readonly IAnswerService _answerService;

    public QuestionService(IRepository repository, IAnswerService answerService)
    {
        _repository = repository;
        _answerService = answerService;
    }

    public async Task<QuestionDto?> GetQuestionByIdAsync(int questionId)
    {
        var question = (await _repository.QueryAsync<QuestionModel>(
            sql: SqlFiles.GetQuestionById,
            param: new
            {
                QuestionId = questionId
            })).FirstOrDefault();

        if (question is null)
            return null;

        var answerDtos = new List<AnswerDto>(5);

        if (!question.IsOpen)
        {
            var answerIds = question.QuestionAnswerIds.ToList();

            answerIds.Add(question.CorrectAnswerId);
            answerDtos = await _answerService.GetAnswerDtosAsync(answerIds.Distinct().ToList()) ?? new List<AnswerDto>(0);
        }

        var dto = new QuestionDto
        {
            Id = question.QuestionId,
            Text = question.QuestionText,
            Image = question.QuestionImage,
            IsOpen = question.IsOpen,
            VideoLink = question.QuestionVideoLink,
            Answers = question.IsOpen ? null : answerDtos.Where(a => question.QuestionAnswerIds.Contains(a.Id)).ToList(),
            CorrectAnswer = question.IsOpen ? null : answerDtos.FirstOrDefault(a => question.CorrectAnswerId == a.Id)
        };

        return dto;
    }

    public async Task<List<QuestionDto>?> GetAllQuestionsAsync()
    {
        var questions = await _repository.QueryAsync<QuestionModel>(
         sql: SqlFiles.GetAllQuestions);

        if (questions is null || !questions.Any())
            return null;

        var answerDtos = new List<AnswerDto>(10);
        var notOpenQuestions = questions.Where(q => !q.IsOpen);
        var answerIds = notOpenQuestions.SelectMany(q => q.QuestionAnswerIds).ToList();
        answerIds.AddRange(notOpenQuestions.Select(q => q.CorrectAnswerId));
        if (answerIds.Count != 0)
        {
            answerDtos = await _answerService.GetAnswerDtosAsync(answerIds.Distinct().ToList()) ?? new List<AnswerDto>(0);
        }
        var questionDtos = questions.Select(question => new QuestionDto
        {
            Id = question.QuestionId,
            Text = question.QuestionText,
            Image = question.QuestionImage,
            IsOpen = question.IsOpen,
            VideoLink = question.QuestionVideoLink,
            Answers = question.IsOpen ? null : answerDtos.Where(a => question.QuestionAnswerIds.Contains(a.Id)).ToList(),
            CorrectAnswer = question.IsOpen ? null : answerDtos.FirstOrDefault(a => question.CorrectAnswerId == a.Id)
        }).ToList();

        return questionDtos;
    }

    public async Task<int> AddQuestionAsync(QuestionDto question)
    {
        List<int> answerIds = null;
        int? correctAnswerId = null;
        if (!question.IsOpen && question.Answers is not null)
        {
            answerIds = new List<int>();
            foreach (var answerDto in question.Answers)
            {
                var answer = await _answerService.GetAnswerByIdAsync(answerDto.Id);
                if (answer is not null)
                {
                    answerIds.Add(answer.Id);
                    continue;
                }

                var answerId = await _answerService.AddAnswerAsync(answerDto);
                answerIds.Add(answerId);
                if (answerDto.IsCorrect)
                    correctAnswerId = answerId;
            }
        }

        return (await _repository.QueryAsync<int>(
            sql: SqlFiles.AddNewQuestion,
            param: new
            {
                QuestionText = question.Text,
                QuestionImage = question.Image,
                QuestionCorrectAnswerId = correctAnswerId,
                QuestionAnswerIds = answerIds,
                question.IsOpen,
                QuestionDifficultId = question.Difficult,
                QuestionVideoLink = question.VideoLink
            })).FirstOrDefault();
    }

    public async Task DeleteQuestionById(int questionId)
    {
        await _repository.ExecuteAsync(sql: SqlFiles.DeleteQuestionById,
            param: new
            {
                QuestionId = questionId
            });
    }
}
