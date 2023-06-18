SELECT u.user_answer_id as UserAnswerId,
                        u.user_answer_text as UserAnswerText,
                        u.answer_id as AnswerId,
                        u.user_id as UserId,
                        u.is_correct as IsCorrect
                        from user_answers u where u.user_id = @UserId