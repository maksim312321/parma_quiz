namespace webapi.Infrastructure.Dtos;

public class UserAnswerDto
{
    public int UserAnswerId { get; set; }

    public string UserAnswerText { get; set; }

    public int? AnswerId { get; set; }

    public int UserId { get; set; }
}
