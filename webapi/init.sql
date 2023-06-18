create table roles (
    role_id serial PRIMARY KEY,
    role_name varchar not null
);

create table difficults (
    difficult_id serial PRIMARY KEY,
    difficult varchar not null
);

create table answers (
    answer_id serial PRIMARY KEY,
    answer_text varchar,
    user_id int4 NOT NULL
);

create table users (
	user_id serial PRIMARY KEY,
	user_password varchar not null,
	user_name varchar not null,
    user_surname varchar not null,
    user_login varchar not null,
    user_role_id integer not null,

	CONSTRAINT user_role_id_fkey FOREIGN KEY (user_role_id) REFERENCES roles(role_id)
);

create table questions (
    question_id serial PRIMARY KEY,
    question_text varchar,
    question_image bytea,
    question_correct_answer_id integer,
    question_answer_ids integer[],
    is_open boolean,
    question_difficult_id integer,
    question_video_link varchar,
    CONSTRAINT question_difficult_id_fkey FOREIGN KEY (question_difficult_id) REFERENCES difficults(difficult_id),
    CONSTRAINT question_correct_answer_id_fkey FOREIGN KEY (question_correct_answer_id) REFERENCES answers(answer_id)
);

create table user_answers (
    user_answer_id serial PRIMARY KEY,
    user_answer_text varchar,
    answer_id integer,
    CONSTRAINT answer_id_fkey FOREIGN KEY (answer_id) REFERENCES answers(answer_id),
	CONSTRAINT user_answers_fk FOREIGN KEY (user_id) REFERENCES users(user_id)
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

ALTER TABLE user_answers ADD user_id int4 NOT NULL;
ALTER TABLE user_answers ADD is_correct bool NOT null default false;
ALTER TABLE user_answers ADD CONSTRAINT user_answers_fk FOREIGN KEY (user_id) REFERENCES users(user_id);