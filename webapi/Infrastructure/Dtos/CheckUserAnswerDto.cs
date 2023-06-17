namespace webapi.Infrastructure.Dtos;

public class CheckUserAnswerDto
{
    public int UserAnswerId { get; set; }

    public bool IsCorrect { get; set; }
}
