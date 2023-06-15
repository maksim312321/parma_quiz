<template>
    <div>
        <SiteHeader :user-name="userName"></SiteHeader>
        <router-view></router-view>
    </div>
</template>

<script>
    import SiteHeader from './components/SiteHeader.vue';

    export default {
        name: 'App',
        components: {
            SiteHeader,
        },
        data() {
            return {
                userName: 'Иван Иванович',
            }
        },
    }
</script>

<style>
    @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@300;400;500&display=swap');

    body {
        font-family: 'Montserrat';
        --van-base-font: 'Montserrat';
    }
</style>
