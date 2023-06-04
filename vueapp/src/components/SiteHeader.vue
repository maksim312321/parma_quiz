<template>
    <header class="header">
        <img src="../assets/parma_logo.svg" alt="parma_logo" />
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

    .header__user {
        font-style: normal;
        font-weight: 600;
        font-size: 28px;
        margin-right: 30px;
    }
</style>