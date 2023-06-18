UPDATE user_answers
SET
is_correct=@IsCorrect,
user_answer_text=@UserAnswerText,
answer_id = @AnswerId
WHERE user_answer_id=@UserAnswerId
