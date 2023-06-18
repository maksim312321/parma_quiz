SELECT u.user_answer_id as UserAnswerId,
                        u.user_answer_text as UserAnswerText,
                        u.answer_id as AnswerId,
                        u.user_id as UserId,
                        u.is_correct as IsCorrect,
                        u.question_id as QuestionId
                        from user_answers u where u.question_id = @QuestionId 
                                            and u.user_id = @UserId