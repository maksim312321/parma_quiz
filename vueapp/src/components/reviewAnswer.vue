<template>
    <div v-if="user">
        <h2>Преверка открытых вопросов, пользователь: <u>{{ user.name }} {{ user.surname }}</u> </h2>
        <div v-for="answer in userAnswers" :key="answer.userAnswerId">
            <div class="wrap" v-if="answer && answer.userAnswerText !== ''">
                <div><b>{{ questionText(answer.questionId) }}</b></div>
                <div class="answer__text">{{ answer.userAnswerText }}</div>
                <div>
                    Правильный ли ответ?
                    <input v-model="answer.isCorrect" type="checkbox">
                    <van-button @click="save(answer)" color="#EC1C24" type="primary">Сохранить</van-button>
                </div>
              
            </div>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                userAnswers: null,
            }
        },
        props: {
            user: Object,
            questions: Object,
        },
        watch: {
            user: {
                async handler() {
                    let res;
                    try {
                        await fetch(`https://localhost:7202/api/userAnswers/${this.user.id}`)
                            .then(response => response.json())
                            .then(response => { res = response });
                        this.userAnswers = res;
                        console.log(this.userAnswers[0].userAnswerText);
                    }
                    catch (e) {
                        this.userAnswers = null;
                        console.log(e);
                    }
                },
                deep: true
            }
        },
        methods: {
            questionText(id) {
                return this.questions.find(item => item.id === id)?.text;
            },
            async save(q) {
                let answer = {
                    "isCorrect": q.isCorrect,
                    "userAnswerId": q.userAnswerId,
                };

                await fetch('https://localhost:7202/api/userAnswers/check', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8'
                    },
                    body: JSON.stringify(answer)
                });

            }
        }
    });
</script>
<style>
    .answer__text {
        position: relative;
        font-style: normal;
        font-weight: 500;
        font-size: 32px;
    }

        .answer__text:before {
            content: "";
            height: 100%;
            position: absolute;
            left: -5px;
            width: 2px;
            background: red;
            position: absolute;
        }

    .wrap {
        display: grid;
        grid-gap: 20px;
        margin-top: 20px;
        padding: 20px;
        background: rgba(217, 217, 217, 0.2);
        border: 3px solid #0F2232;
        border-radius: 10px;
    }
</style>