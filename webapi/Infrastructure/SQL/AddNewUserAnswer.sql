INSERT INTO user_answers(
    user_answer_text,
    answer_id,
    user_id,
    is_correct,
    question_id
) 
VALUES 
  (
    @UserAnswerText,
    @AnswerId,
    @UserId,
    @IsCorrect,
    @QuestionId
  )
  RETURNING user_answer_id