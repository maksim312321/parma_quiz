<template>
    <header class="header">
        <div class="header__left">
            <router-link to="/">
                <img src="../assets/parma_logo.svg" alt="parma_logo" />
            </router-link>
            <router-link to="/admin_main_page"><span>Панель администратора</span></router-link>
        </div>
        <div class="header__user">
            {{userName}}
        </div>
</header>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        props: {
            userName: String,
        },
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
</style>