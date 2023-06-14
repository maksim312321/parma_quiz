INSERT INTO user_answers(
    user_answer_text,
    answer_id,
    user_id
) 
VALUES 
  (
    @UserAnswerText,
    @AnswerId,
    @UserId
  )
  RETURNING user_answer_id