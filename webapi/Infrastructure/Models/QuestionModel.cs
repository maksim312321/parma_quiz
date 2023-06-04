using System;
namespace webapi.Infrastructure.Models;

public class QuestionModel
{
    public int QuestionId { get; set; }

    public string QuestionText { get; set; }

    public byte[]? QuestionImage { get; set; }

    public int CorrectAnswerId { get; set; }

    public int[] QuestionAnswerIds { get; set; }

    public bool IsOpen { get; set; }

    public int QuestionDifficultId { get; set; }

    public string QuestionVideoLink { get; set; }
}

