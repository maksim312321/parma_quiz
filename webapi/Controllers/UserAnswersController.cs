using Microsoft.AspNetCore.Mvc;
using webapi.Infrastructure.Dtos;
using webapi.Services;
using webapi.Services.Implementations;

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAnswersController : ControllerBase
{
    private readonly IUserAnswersService _userAnswersService;

    public UserAnswersController(IUserAnswersService userAnswersService) 
    { 
        _userAnswersService = userAnswersService;
    }

    [HttpGet("{userId}")]
    //[AuthentificationPermission(Permissions = "UserManagement")]
    public async Task<List<UserAnswerDto>?> GetAllUserAnswersByUserIdAsync(int userId)
        => await _userAnswersService.GetAllUserAnswersByUserIdAsync(userId);

    [HttpPost]
    public async Task<int> AddNewUserAnswer(UserAnswerDto userAnswer)
        => await _userAnswersService.AddUserAnswerAsync(userAnswer);

    [HttpPost("check")]
    public async Task CheckTheUserAnswerAsync(CheckUserAnswerDto checkUserAnswerDto) =>
        await _userAnswersService.CheckTheUserAnswerAsync(checkUserAnswerDto);
}
