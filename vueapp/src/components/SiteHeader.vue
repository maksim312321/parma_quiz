<template>
    <header class="header">
        <div class="header__left">
            <router-link to="/">
                <img src="../assets/parma_logo.svg" alt="parma_logo" />
            </router-link>
            <router-link v-if="isAdmin" to="/admin_main_page"><span class="menu__link">Проверка ответов</span></router-link>
            <router-link v-if="isAdmin" to="/edit_quiz_page"><span class="menu__link">Панель администратора</span></router-link>
        </div>
        <div v-if="user.name" class="header__user">
            {{user.name}} <u @click="logout">выйти</u>
        </div>
</header>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        props: {
            user: Object,
        },
        computed: {
            isAdmin() {
                return this.user.role == '2';
            }
        },
        methods: {
            logout() {
                document.cookie = 'user=';
                this.$router.push('/login');
            }
        }
    });
</script>

<style>
    .header {
        height: 80px;
        background: #EC1C24;
        color: #ffffff;
        display: flex;
        align-items: center;
        justify-content: space-between;
    }

    .header__left {
        display: flex;
        align-items: center;
        color: white;
    }

    .header__left span {
        color: white!important;
    }

    .header__user {
        font-style: normal;
        font-weight: 600;
        font-size: 28px;
        margin-right: 30px;
    }

    .header__user u {
        font-size: 18px;
    }

    .menu__link {
        margin-right: 20px;
    }
</style>