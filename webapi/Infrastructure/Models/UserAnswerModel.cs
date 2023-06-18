namespace webapi.Infrastructure.Models;

public class UserAnswerModel
{
    public int UserAnswerId { get; set; }

    public int QuestionId { get; set; }

    public string UserAnswerText { get; set; }

    public int? AnswerId { get; set; }

    public int UserId { get; set; }

    public bool? IsCorrect { get; set; }
}
