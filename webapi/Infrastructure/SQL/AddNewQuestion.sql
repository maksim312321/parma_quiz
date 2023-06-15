INSERT INTO questions(
    question_text,
    question_image,
    question_correct_answer_id,
    question_answer_ids,
    is_open,
    question_difficult_id,
    question_video_link
) 
VALUES 
  (
    @QuestionText, 
    @QuestionImage, 
    @QuestionCorrectAnswerId, 
    @QuestionAnswerIds,
    @IsOpen,
    @QuestionDifficultId,
    @QuestionVideoLink
  ) RETURNING question_id