using webapi.Enums;

namespace webapi.Infrastructure.Dtos;

public class QuestionDto
{
    public string Text { get; set; }

    public int Id { get; set; }

    public byte[]? Image { get; set; }

    public AnswerDto? CorrectAnswer { get; set; }

    public List<AnswerDto>? Answers { get; set; }

    public bool IsOpen { get; set; }

    public Difficult Difficult { get; set; }

    public string? VideoLink { get; set; }
}
