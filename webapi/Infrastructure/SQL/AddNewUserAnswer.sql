INSERT INTO user_answers(
    user_answer_text,
    answer_id,
    user_id,
    is_correct
) 
VALUES 
  (
    @UserAnswerText,
    @AnswerId,
    @UserId,
    @IsCorrect
  )
  RETURNING user_answer_id