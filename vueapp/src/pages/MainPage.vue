<template>
    <div class="container container__main-page">
        <div v-if="infoBlocks">
            <div class="block-info__button"
                 v-for="infoBlock in infoBlocks"
                 :key="infoBlock.id"
                 @click="selectedInfoBlock = infoBlock">
                {{ infoBlock.title }}
            </div>
        </div>
        <div>
            <div v-if="selectedInfoBlock">
                <h3>{{ selectedInfoBlock.subtitle }}</h3>

                {{ selectedInfoBlock.content }}
            </div>
            <div v-else>
                Квест-тур PARMA Technologies Group
            </div>
            <h3>Ваш результат: {{this.resultsInfo.correctAnswers}} / {{this.questionsCount}}</h3>
            <h3>На проверке: {{this.resultsInfo.reviewAnswers}}</h3>
            <router-link to="/quiz">
                <van-button color="#EC1C24" type="primary">Начать опрос</van-button>
            </router-link>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                infoBlocks: null,
                selectedInfoBlock: null,
                questionsCount: null,
                resultsInfo: {},
            };
        },
        created() {
            this.infoBlocks = JSON.parse('[{"title":"БЛОКИ С ИНФОРМАЦИЕЙ","subtitle":"Как получить все справки этого мира в компании?","content":"Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то воттак-то","id":0},{"title":"БЛОКИ С ИНФОРМАЦИЕЙ","subtitle":"Как получить все справки этого мира в компании?","content":"Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то воттак-то","id":1},{"title":"БЛОКИ С ИНФОРМАЦИЕЙ","subtitle":"Как получить все справки этого мира в компании?","content":"Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то воттак-то","id":2},{"title":"БЛОКИ С ИНФОРМАЦИЕЙ","subtitle":"Как получить все справки этого мира в компании?","content":"Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то воттак-то","id":3},{"title":"БЛОКИ С ИНФОРМАЦИЕЙ","subtitle":"Как получить все справки этого мира в компании?","content":"Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то воттак-то","id":4},{"title":"БЛОКИ С ИНФОРМАЦИЕЙ","subtitle":"Как получить все справки этого мира в компании?","content":"Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то вот-так-то Так-то воттак-то","id":5}]')
            this.loadResults();
        },
        methods: {
            async loadResults() {
                const user = JSON.parse(window.getCookie('user'));
                let res;
                await fetch('https://localhost:7202/question/all')
                    .then(response => response.json())
                    .then(response => { res = response });
                this.questionsCount = res.length;

                try {
                    await fetch(`https://localhost:7202/api/userAnswers/${user.id}`)
                        .then(response => response.json())
                        .then(response => { res = response });
                }
                catch (e) {
                    console.log(e);
                }

                this.resultsInfo.correctAnswers = 0;
                this.resultsInfo.reviewAnswers = 0;

                res.forEach(item => {
                    if (item.isCorrect) {
                        this.resultsInfo.correctAnswers++;
                    }
                    if (item.isCorrect === null) {
                        this.resultsInfo.reviewAnswers++;
                    }
                });
            }
        },
    });
</script>

<style>
    .container {
        width: 80%;
        margin: 0 auto;
        margin-top: 80px;
    }

    .container__main-page {
        width: 80%;
        margin: 0 auto;
        display: grid;
        grid-template-columns: 20% 80%;
        grid-gap: 30px;
        margin-top: 80px;
    }

    .block-info__button {
        background: #E9ECEE;
        text-align: center;
        cursor: pointer;
        font-family: 'Montserrat';
        font-weight: 800;
        padding: 13px;
        margin-top: 11px;
    }

    .block-info__button:first-child {
        margin-top: 0;
    }
</style>