<template>
    <div class="container">
        <div v-if="loading" class="container__loader">
            <van-loading size="100px" type="spinner" color="#EC1C24" />
        </div>
        <div v-else class="quiz">
            <div class="quiz__main">
                <img class="quiz__image" v-if="currentQuestion.image" src="{{currentQuestion.image}}" alt="q_image" />
                <img class="quiz__image" v-else src="../assets/default_quiz_image.png" alt="q_image" />
                <h2>Тестировнаие для младших сотрудников</h2>
                <div class="quiz__progress">
                    <h1>Вопрос {{ currentQuestionIndex + 1 }} из {{ this.questions.length }}</h1>
                    <div class="quiz__progress-bar">
                        <div class="quiz__progress-done"
                             :style="{ 'width':  (currentProgress + '%')}"
                        >

                        </div>
                    </div>
                </div>
            </div>
            <div class="quiz__question">
                <h2 class="question__text">{{ currentQuestion.text }}</h2>
                <div v-if="currentQuestion.isOpen">
                    <input class="question__input" v-model="inputAnswer" type="type" name="name" value="" placeholder="Введите ответ..." />
                </div>
                <div v-else class="question__answers">
                    <div v-for="answer in currentQuestion.answers"
                         :key="answer.id"
                         class="question__answer"
                         :class=" { 'question__answer--selected' : (answer.id == selectedAnswer?.id)} "
                         @click="selectAnswer(answer)">
                        {{ answer.text }}
                    </div>
                </div>
                <van-button class="question__answer-btn" @click="onAnswerBtnClick()" color="#EC1C24" type="primary">Ответить</van-button>
            </div>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                loading: false,
                questions: null,
                currentQuestion: null,
                currentQuestionIndex: 0,
                selectedAnswer: null,
                inputAnswer: null,
            };
        },
        created() {
            this.fetchQuiz();
        },
        computed: {
            currentProgress() {
                return (this.currentQuestionIndex + 1) / this.questions.length * 100;
            },
        },
        watch: {
            '$route': 'fetchData'
        },
        methods: {
            selectAnswer(answer) {
                if (this.selectedAnswer?.id === answer.id) {
                    this.selectedAnswer = null;
                } else {
                    this.selectedAnswer = answer;
                }
            },
            onAnswerBtnClick() {
                if (this.currentQuestion.isOpen) {
                    if (this.inputAnswer === null) {
                        alert('Ответ пуст');
                        return;
                    }

                    this.inputAnswer = null;
                } else {
                    if (this.selectedAnswer === null) {
                        alert('Ответ не выбран');
                        return;
                    }

                    this.selectedAnswer = null;
                }

                this.switchScreenToNextAnswer();

                this.sendAnswer();
            },
            switchScreenToNextAnswer() {
                if ((this.questions.length - 1) === this.currentQuestionIndex) {
                    alert('Тестирование пройдено');
                    this.$router.push('/')
                    return;
                }

                this.currentQuestionIndex++;
                this.currentQuestion = this.questions[this.currentQuestionIndex];
            },
            sendAnswer() {

            },
            fetchQuiz() {
                this.loading = true; 
                fetch('https://localhost:7202/question/all')
                    .then(response => response.json())
                    .then(response => {
                        this.loading = false;
                        //this.questions = JSON.parse('[{"text":"Вам нужно закрыть практику в учебном заведении, нужно ли вам отправлять ваш отчет на проверку и кому?","id":1,"image":null,"correctAnswer":null,"answers":null,"isOpen":true,"difficult":0,"videoLink":null},{"text":"В каком мессенджере следует общаться по рабочим вопросам?","id":2,"image":null,"correctAnswer":{"id":3,"text":"Microsoft Teams"},"answers":[{"id":1,"text":"Viber"},{"id":2,"text":"Telegram"},{"id":3,"text":"Microsoft Teams"},{"id":4,"text":"Whats App"}],"isOpen":false,"difficult":0,"videoLink":null}]');
                        this.questions = response;
                        this.currentQuestion = this.questions[this.currentQuestionIndex];
                    });
            },
        },
    });
</script>

<style>
    .container__loader {
        margin: 0 auto;
        width: min-content;
    }

    .quiz {
        display: grid;
        grid-template-columns: 50% 50%;
        grid-gap: 30px;
    }

    .quiz__question {
        display: grid;
        grid-gap: 15px;
    }

    .quiz__image {
        width: 100%;
        max-height: 300px;
        background-size: cover;
        overflow: hidden;
    }

    .quiz__progress-bar {
        width: 100%;
        height: 42px;
        border-radius: 50px;
        background: #E9ECEE;
        border: 3px solid #0F2232;
    }

    .quiz__progress-done {
        height: 100%;
        background: #EC1C24;
        border-radius: 50px;
    }

    .question__text {
        padding: 50px 30px;
        text-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
        border: 3px solid #0F2232;
        border-radius: 55px;
        margin: 0;
        height: fit-content;
    }

    .question__answers {
        display: grid;
        grid-template-columns: 50% 50%;
        grid-gap: 10px;
    }

    .question__answer {
        cursor: pointer;
        text-align: center;
        border: 3px solid #0F2232;
        border-radius: 50px;
        width: 40%;
        margin: 0 auto;
        padding: 10px 0;
        height: fit-content;
    }

    .question__answer--selected {
        background: #D4E8E4;
    }

    .question__input {
        height: 171px;
        width: 100%;
        border: 3px solid #0F2232;
        filter: drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25));
        border-radius: 50px;
        font-size: 1.5em;
    }

    .question__answer-btn {
        border-radius: 50px !important;
        margin-left: auto !important;
        width: 150px;
    }
</style>