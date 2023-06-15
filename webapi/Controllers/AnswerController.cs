using Microsoft.AspNetCore.Mvc;
using webapi.Infrastructure.Dtos;
using webapi.Services;
using webapi.Services.Implementations;

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswerController : ControllerBase
{
    private readonly IAnswerService _answerService;

    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }

    [HttpGet("{answerId}")]
    //[AuthentificationPermission(Permissions = "UserManagement")]
    public Task<AnswerDto?> GetAnswerByIdAsync(int answerId)
       => _answerService.GetAnswerByIdAsync(answerId);

    [HttpDelete("{answerId}")]
    public Task DeleteAnswerByIdAsync(int answerId) =>
        _answerService.DeleteAnswerByIdAsync(answerId);

    [HttpGet]
    public Task<List<AnswerDto>?> GetAllAnswersAsync()
       => _answerService.GetAllAnswerDtosAsync();
}
