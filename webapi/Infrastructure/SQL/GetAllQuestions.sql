select q.question_id as QuestionId,
           q.question_text as QuestionText,
           q.question_image as QuestionImage,
           q.question_correct_answer_id as CorrectAnswerId,
           q.question_answer_ids as QuestionAnswerIds,
           q.is_open as IsOpen,
           q.question_difficult_id as QuestionDifficultId,
           q.question_video_link as QuestionVideoLink
         from questions q