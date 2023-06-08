using System.Threading;
using webapi.Infrastructure.DatabaseUtils;
using webapi.Infrastructure.Dtos;
using webapi.Infrastructure.Models;

namespace webapi.Services.Implementations;

public class QuestionService : IQuestionService
{
    private readonly IRepository _repository;
    private readonly IDatabaseConnectionFactory _dbConnectionFactory;

    public QuestionService(IRepository repository, IDatabaseConnectionFactory databaseConnectionFactory)
    {
        _repository = repository;
        _dbConnectionFactory = databaseConnectionFactory;
    }

    public async Task<QuestionDto> GetQuestionByIdAsync(int questionId)
    {
        var questionQuery = string.Format(@"select q.question_id as QuestionId,
											q.question_text as QuestionText,
										   	q.question_image as QuestionImage,
										   	q.question_correct_answer_id as CorrectAnswerId,
										  	q.question_answer_ids as QuestionAnswerIds,
										  	q.is_open as IsOpen,
                                            q.question_difficult_id as QuestionDifficultId,
										   	q.question_video_link as QuestionVideoLink
									from questions q 
									where q.question_id = {0}", questionId);

        var question = (await _repository.QueryAsync<QuestionModel>(
            sql: questionQuery)).FirstOrDefault();

        if (question is null)
            return null;

        var answerDtos = new List<AnswerDto>(5);

        if (!question.IsOpen)
        {
            var answerIds = string.Join(",", question.QuestionAnswerIds) + "," + question.CorrectAnswerId;

            var answerQuerry = string.Format(@"select a.answer_id as AnswerId,
											a.answer_text as AnswerText,										   
									from answers a
									where a.answer_id in ({0})", answerIds);
            var answersModels = await _repository.QueryAsync<AnswerModel>(
                sql: answerQuerry);
            answerDtos = answersModels.Select(a => new AnswerDto()
            {
                Id = a.AnswerId,
                Text = a.AnswerText
            }).ToList();
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
        var questionsQuery = string.Format(@"select q.question_id as QuestionId,
           q.question_text as QuestionText,
           q.question_image as QuestionImage,
           q.question_correct_answer_id as CorrectAnswerId,
           q.question_answer_ids as QuestionAnswerIds,
           q.is_open as IsOpen,
           q.question_difficult_id as QuestionDifficultId,
           q.question_video_link as QuestionVideoLink
         from questions q");

        var questions = await _repository.QueryAsync<QuestionModel>(
         sql: questionsQuery);

        if (questions is null || !questions.Any())
            return null;

        var answerDtos = new List<AnswerDto>(10);
        var notOpenQuestions = questions.Where(q => !q.IsOpen);
        var answerIds = notOpenQuestions.SelectMany(q => q.QuestionAnswerIds).ToList();
        answerIds.AddRange(notOpenQuestions.Select(q => q.CorrectAnswerId));
        var answerIdsString = string.Join(",", answerIds.Distinct());
        if (answerIdsString.Length != 0)
        {

            var answerQuerry = string.Format(@"select a.answer_id as AnswerId,
                                               a.answer_text as AnswerText             
                                             from answers a
                                             where a.answer_id in ({0})", answerIdsString);
            var answersModels = await _repository.QueryAsync<AnswerModel>(
                sql: answerQuerry);
            answerDtos = answersModels.Select(a => new AnswerDto()
            {
                Id = a.AnswerId,
                Text = a.AnswerText
            }).ToList();
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

    public async Task AddQuestionAsync(QuestionDto question)
    {

    }
}
