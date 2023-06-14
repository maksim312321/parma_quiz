INSERT INTO answers(
    answer_text
) 
VALUES 
  (
    @AnswerText
  ) RETURNING answer_id