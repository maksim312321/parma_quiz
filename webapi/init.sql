CREATE TABLE answers (
	answer_id serial4 NOT NULL,
	answer_text varchar NULL,
	CONSTRAINT answers_pkey PRIMARY KEY (answer_id)
);

CREATE TABLE difficults (
	difficult_id serial4 NOT NULL,
	difficult varchar NOT NULL,
	CONSTRAINT difficults_pkey PRIMARY KEY (difficult_id)
);

CREATE TABLE roles (
	role_id serial4 NOT NULL,
	role_name varchar NOT NULL,
	CONSTRAINT roles_pkey PRIMARY KEY (role_id)
);

CREATE TABLE questions (
	question_id serial4 NOT NULL,
	question_text varchar NULL,
	question_image bytea NULL,
	question_correct_answer_id int4 NULL,
	question_answer_ids _int4 NULL,
	is_open bool NULL,
	question_difficult_id int4 NULL,
	question_video_link varchar NULL,
	CONSTRAINT questions_pkey PRIMARY KEY (question_id),
	CONSTRAINT question_correct_answer_id_fkey FOREIGN KEY (question_correct_answer_id) REFERENCES answers(answer_id),
	CONSTRAINT question_difficult_id_fkey FOREIGN KEY (question_difficult_id) REFERENCES difficults(difficult_id)
);

CREATE TABLE users (
	user_id serial4 NOT NULL,
	user_password varchar NOT NULL,
	user_name varchar NOT NULL,
	user_surname varchar NOT NULL,
	user_login varchar NOT NULL,
	user_role_id int4 NOT NULL,
	CONSTRAINT users_pkey PRIMARY KEY (user_id),
	CONSTRAINT user_role_id_fkey FOREIGN KEY (user_role_id) REFERENCES roles(role_id)
);

CREATE TABLE user_answers (
	user_answer_id serial4 NOT NULL,
	user_answer_text varchar NULL,
	answer_id int4 NULL,
	user_id int4 NOT NULL,
	is_correct bool NULL,
    question_id int4 NOT NULL,
	CONSTRAINT user_answers_pkey PRIMARY KEY (user_answer_id),
	CONSTRAINT answer_id_fkey FOREIGN KEY (answer_id) REFERENCES answers(answer_id),
    CONSTRAINT questions_fk FOREIGN KEY (question_id) REFERENCES questions(question_id),
	CONSTRAINT users_fk FOREIGN KEY (user_id) REFERENCES users(user_id)
);

INSERT INTO roles (role_id, role_name) VALUES(1, 'User');
INSERT INTO roles (role_id, role_name) VALUES(2, 'Admin');


INSERT INTO difficults (difficult_id, difficult) VALUES(1, 'Easy');
INSERT INTO difficults (difficult_id, difficult) VALUES(2, 'Medium');
INSERT INTO difficults (difficult_id, difficult) VALUES(3, 'Hard');

INSERT INTO answers (answer_text) VALUES('Viber');
INSERT INTO answers (answer_text) VALUES('Telegram');
INSERT INTO answers (answer_text) VALUES('Microsoft Teams');
INSERT INTO answers (answer_text) VALUES('Whats App');

INSERT INTO questions (question_text,
    is_open,
    question_difficult_id) VALUES('Вам нужно закрыть практику в учебном заведении, нужно ли вам отправлять ваш отчет на проверку и кому?', true, 2);
INSERT INTO questions
(question_id, question_text, question_image, question_correct_answer_id, question_answer_ids, is_open, question_difficult_id, question_video_link)
VALUES(2, 'В каком мессенджере следует общаться по рабочим вопросам?', NULL, 3, '{1,2,3,4}', false, 1, NULL);