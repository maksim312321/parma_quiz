<template>
    <div class="container">
        <div class="final_page">
            <div class="final_page__text">
                <span class="final_page__text-paragraph">Поздравляем, ты прошел квест</span>
                <span class="final_page__text-paragraph">Спасибо за твое потраченное время, благодаря этому квесту, твое руководство получит оценку твоих знаний.</span>
                <span class="final_page__text-paragraph">Надеемся, что квест помог тебе погрузиться в корпаративную культуры компании.</span>
                <van-button class="final_page__to-home" @click="toHome()" color="#EC1C24" type="primary">Домой</van-button>
                <div></div>
                <van-button class="final_page__to-res" @click="toResults()" color="#EC1C24" type="primary">Результаты</van-button>
            </div>
            <div class="final_page__img">
                <img src="../assets/final_page_image.png" alt="final image" />
            </div>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
            };
        },
        methods: {
            toHome() {
                this.$router.push('/');
            },
            toResults() {
                this.$router.push('/');
            },
        },
    });
</script>

<style>
    .container {
        width: 80%;
        margin: 0 auto;
        margin-top: 80px;
    }

    .final_page {
        display: grid;
        grid-template-columns: 50% 50%;
    }

    .final_page__text-paragraph {
        display: block;
        font-family: 'Montserrat';
        font-weight: 400;
        font-size: 25px;
        line-height: 30px;
        margin-bottom: 30px;
    }

    .final_page__img {
        width: 600px;
    }

    .final_page__to-home,
    .final_page__to-res {
        border-radius: 50px !important;
        width: 300px;
    }

    .final_page__to-res {
        margin-top: 30px!important;
    }
</style>