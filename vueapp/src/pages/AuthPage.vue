<template>
    <div class="container">
        <form v-if="!loading" action="/" method="post" class="auth__form">
            <input class="auth__input" v-model="login" placeholder="Логин"/>
            <input class="auth__input" v-model="password" type="password" placeholder="Пароль"/>
            <van-button @click="auth" class="auth__btn" color="#EC1C24" width="100px" type="primary">Войти</van-button>
        </form>
        <div v-else class="loader">
            <van-loading size="100px" type="spinner" color="#EC1C24" />
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                login: null,
                password: null,
                loading: false,
            };
        },
        methods: {
            async auth() {
                this.loading = true;
                const user = {
                    "password": this.password,
                    "login": this.login,
                };
                let response = await fetch('https://localhost:7202/api/users/authorize', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8'
                    },
                    body: JSON.stringify(user)
                });

                try {
                    const result = await response.json();
                    this.loading = false;
                    document.cookie = `user=${JSON.stringify(result)}`;
                    this.$router.push('/');
                }
                catch (e) {
                    
                    alert('Неверные данные');
                    this.loading = false;
                }
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

    .loader {
        max-width: min-content;
        margin: 0 auto;
    }
</style>