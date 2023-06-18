using webapi.Infrastructure.Dtos;
using webapi.Infrastructure.Models;

namespace webapi.Services;

public interface IUserAnswersService
{
    public Task<List<UserAnswerDto>?> GetAllUserAnswersByUserIdAsync(int userId);

    public Task<int> AddUserAnswerAsync(UserAnswerDto userAnswer);

    public Task CheckTheUserAnswerAsync(CheckUserAnswerDto dto);
}
