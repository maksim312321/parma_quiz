using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using webapi.Infrastructure.DatabaseUtils;
using webapi.Infrastructure.Dtos;
using webapi.Services;
using webapi.Services.Implementations;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    //[HttpGet("all")]
    //public async Task<List<QuestionDto>> GetQuestions()
    //{
    //    //return await _questionService.GetAllQuestionsAsync();
    //}

    [HttpGet("{questionId}")]
    public async Task<QuestionDto> GetQuestion(int questionId)
    {
        return await _questionService.GetQuestionByIdAsync(questionId);
    }
}
