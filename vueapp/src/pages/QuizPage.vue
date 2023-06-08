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
                    <h1>Вопрос {{ currentQuestionIndex }} из {{ this.questions.length }}</h1>
                    <div class="quiz__progress-bar">
                        <div class="quiz__progress-done"
                             :style="{ 'width':  (currentProgress + '%')}"
                        >

                        </div>
                    </div>
                </div>
            </div>
            <div class="quiz__question">

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
            };
        },
        created() {
            this.fetchQuiz();
        },
        computed: {
            currentProgress() {
                console.log(this.currentQuestionIndex, this.questions.length);
                return this.currentQuestionIndex / this.questions.length * 100;
            }
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchQuiz() {
                this.loading = true; 
                fetch('https://localhost:7202/question/1', {
                    mode: 'no-cors'
                }).then(() => {
                    this.loading = false;
                    this.questions = JSON.parse('[{"text":"Куда необходимо обратиться сотруднику, для получения справки 2НДФЛ ?","id":1,"image":null,"correctAnswer":null,"answers":null,"isOpen":true,"difficult":0,"videoLink":null},{"text":"Куда необходимо обратиться сотруднику, для получения справки 2НДФЛ ?","id":2,"image":null,"correctAnswer":null,"answers":null,"isOpen":true,"difficult":0,"videoLink":null},{"text":"Куда необходимо обратиться сотруднику, для получения справки 2НДФЛ ?","id":3,"image":null,"correctAnswer":null,"answers":null,"isOpen":true,"difficult":0,"videoLink":null},{"text":"Куда необходимо обратиться сотруднику, для получения справки 2НДФЛ ?","id":4,"image":null,"correctAnswer":null,"answers":null,"isOpen":true,"difficult":0,"videoLink":null}]');
                    this.currentQuestion = this.questions[this.currentQuestionIndex];
                });
            }
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
</style>