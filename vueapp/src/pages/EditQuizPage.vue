<template>
    <div class="container">
        <div class="tabs">
            <h1 :style="styleForQuizTab" @click="setTab('quiz')">
                Редактор вопросов
            </h1>
            <h1 :style="styleForUserTab" @click="setTab('user')">
                Добавление пользователей
            </h1>
        </div>
        <div v-show="activeTab === 'quiz'" class="edit_quiz">
            <div class="edit_quiz__questions">
                <h2>Текущие вопросы</h2>
                <div class="edit_quiz__question" v-for="(q, index) in questions" :key="q.id">
                    <span class="edit_quiz__index">{{index + 1}}</span> <span class="edit_quiz__text">{{ q.text }}</span> <img @click="deleteQuestion(q)" src="../assets/delete_image.svg" alt="delete" />
                </div>
            </div>
            <div class="edit_quiz__edit">
                <h2 class="edit_quiz__edit-header">Добавление вопросов</h2>
                <span>Текст вопроса: </span>
                <input v-model="newQuestion.text" type="type" name="name" placeholder="Текст вопроса" />
                <span>Тип вопроса:</span>
                <select v-model="newQuestion.isOpen">
                    <option :value="true">Открытый</option>
                    <option :value="false">Закрытый</option>
                </select>
                <span>Сложность:</span>
                <select v-model="newQuestion.difficult">
                    <option :value="1">Легкий</option>
                    <option :value="2">Средний</option>
                    <option :value="3">Сложный</option>
                </select>


                <span v-if="!newQuestion.isOpen">Варианты ответов:</span>
                <div v-if="!newQuestion.isOpen">
                    <div v-for="answer in newQuestion.answers" :key="answer.id">
                        <input type="type" v-model="answer.text" />
                    </div>
                </div>

                <span v-if="!newQuestion.isOpen">Правильный ответ:</span>
                <select v-if="!newQuestion.isOpen" v-model="newQuestion.correctAnswer">
                    <option v-for="answer in newQuestion.answers" :key="answer.id" :value="answer">{{ answer.text }}</option>
                </select>

                <van-button class="edit_quiz__add-btn" @click="addAnswer()" color="#EC1C24" type="primary">Добавить вопрос</van-button>
            </div>
        </div>
        <div class="edit_user" v-show="activeTab === 'user'">
            <span>Имя пользователя</span><input v-model="newUser.name" placeholder="Имя пользователя" />
            <span>Фамилия пользователя</span><input v-model="newUser.surname" placeholder="Фамилия пользователя" />
            <span>Логин</span><input v-model="newUser.login" placeholder="Логин" />
            <span>Пароль</span><input v-model="newUser.password" placeholder="Пароль" />
            <span>Роль</span><select v-model="newUser.role">
                <option :value="1">Пользователь</option>
                <option :value="2">Администратор</option>
            </select>
            <van-button class="edit_quiz__add-btn" @click="addUser()" color="#EC1C24" type="primary">Добавить пользователя</van-button>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                activeTab: 'quiz',
                users: null,
                questions: [],
                questionsCount: null,
                selectedUser: null,
                newQuestion: {
                    text: null,
                    isOpen: true,
                    difficult: 1,
                    answers: [
                        {
                            id: 1,
                            text: 'Вариант 1',
                        },
                        {
                            id: 2,
                            text: 'Вариант 2',
                        },
                        {
                            id: 3,
                            text: 'Вариант 3',
                        },
                        {
                            id: 4,
                            text: 'Вариант 4',
                        },
 
                    ],
                    correctAnswer: null,
                },
                newUser: {
                    "name": null,
                    "password": null,
                    "role": null,
                    "login": null,
                    "surname": null,
                }
            };
        },
        created() {
            this.fetchQuiz();
        },
        computed: {
            styleForQuizTab() {
                let color = this.activeTab === 'quiz' ? '#000000' : '#cccccc';
                return { color: color };
            },
            styleForUserTab() {
                let color = this.activeTab === 'user' ? '#000000' : '#cccccc';
                return { color: color };
            },
        },
        methods: {
            fetchQuiz() {
                try {
                    fetch('https://localhost:7202/question/all')
                        .then(response => response.json())
                        .then(response => {
                            this.questions = response;
                        });
                }
                catch (e) {
                    console.log(e); 
                }
            },
            deleteQuestion(itemForDel) {
                //fetch('https://localhost:7202/question/' + itemForDel.id, {
                //    method: 'DELETE',
                //})
                this.questions = this.questions.filter(item => {
                    return JSON.stringify(item) !== JSON.stringify(itemForDel)
                });
            },
            addAnswer() {
                if (this.newQuestion.text === null || (this.newQuestion.isOpen == false && this.newQuestion.correctAnswer === null)) {
                    alert('Заполните поля формы');
                    return;
                }
                this.questions.push(Object.assign({}, this.newQuestion));
            },
            setTab(tab) {
                this.activeTab = tab;
            },
            async addUser() {
                let response = await fetch('https://localhost:7202/api/users', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8'
                    },
                    body: JSON.stringify(this.newUser)
                });

                let result = await response.json();
                console.log(result)
                alert('Пользователь добавлен');
            }
        }
    });
</script>

<style>
    .edit_user {
        width: 50%;
        margin: 20px auto;
        display: grid;
        /* grid-gap: 50px; */
        align-items: center;
        grid-template-columns: 50% 50%;
        border: 1px solid grey;
        border-radius: 15px;
        padding: 20px;
    }

    .tabs {
        display: grid;
        grid-gap: 50px;
        grid-template-columns: 50% 50%;
    }

    .tabs h1 {
        cursor: pointer;
        text-align: center;
    }

    .edit_quiz {
        display: grid;
        grid-gap: 50px;
        grid-template-columns: 50% 50%;
    }

    .edit_quiz__edit-header {
        grid-column: 1 / 3;
    }

    .edit_quiz__add-btn {
        grid-column: 1 / 3;
        width: 50%!important;
        margin: 0 auto!important;
    }

    .edit_quiz h1 {
        text-align: center;
    }

    .edit_quiz input,
    .edit_quiz select,
    .edit_user input,
    .edit_user select {
        margin: 10px 0;
        border: 2px solid #0F2232;
        border-radius: 50px;
        padding: 10px;
        font-family: 'Montserrat' !important;
        font-size: 10px;
    }

    .edit_quiz__question {
        font-size: 20px;
        margin: 15px;
        display: flex;
        justify-content: space-between;
        align-items: center;
        border: 3px solid #0F2232;
        border-radius: 50px;
        padding: 5px 20px;
    }

    .edit_quiz__text {
        width: 80%;
    }

    .edit_quiz__question img {
        cursor: pointer;
        width: 20px;
    }

    .edit_quiz__index {
        color: red;
        font-size: 35px;
    }

    .edit_quiz__edit {
        display: grid;
        grid-template-columns: 50% 50%;
        align-items: center;
        padding: 20px 50px;
        border: 1px solid grey;
        border-radius: 15px;
    }
</style>