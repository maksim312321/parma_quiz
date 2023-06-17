UPDATE user_answers
SET
is_correct=@IsCorrect
WHERE user_answer_id=@UserAnswerId
