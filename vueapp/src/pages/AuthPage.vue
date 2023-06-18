<template>
    <div class="container">
        <form @submit.prevent="auth" action="/" method="post" class="auth__form">
            <input class="auth__input" v-model="login" placeholder="Логин"/>
            <input class="auth__input" v-model="password" placeholder="Пароль"/>
            <van-button class="auth__btn" color="#EC1C24" width="100px" type="primary">Войти</van-button>
        </form>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                login: null,
                password: null,
            };
        },
        methods: {
            auth() {
                
            }
        },
    });
</script>

<style>
    .auth__form {
        width: 30%;
        margin: 0 auto;
        display: flex;
        flex-direction: column;
    }

    .auth__input {
        margin: 10px 0;
        border: 2px solid #0F2232;
        border-radius: 50px;
        padding: 10px;
    }

    .auth__btn {
        margin-top: 10px!important;
    }
</style>