<template>
    <div>
        <div v-if="loading">Loading...</div>
        <div class="quiz__cards"
             v-else>
            <QuizCard :title="testData"></QuizCard>
            <QuizCard :title="testData"></QuizCard>
            <QuizCard :title="testData"></QuizCard>
        </div>
        <van-button @click="showPopup=!showPopup" type="primary">Show popup</van-button>
        <van-popup v-model:show="showPopup">
            <QuizCard :title="testData"></QuizCard>
        </van-popup>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import QuizCard from '../components/QuizCard.vue';

    export default defineComponent({
        components: {
            QuizCard
        },
        data() {
            return {
                loading: false,
                post: null,
                testData: "testString",
                showPopup: false,
            };
        },
        created() {
            this.fetchData();
        },
        watch: {
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.post = null;
                this.loading = true;

                fetch('weatherforecast')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>

<style>
    .quiz__cards {
        width: 1070px;
        margin: 0 auto;
        display: grid;
        grid-template-columns: 1fr 1fr 1fr;
    }
</style>