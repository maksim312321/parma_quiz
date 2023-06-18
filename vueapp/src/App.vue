<template>
    <div>
        <SiteHeader :user="user"></SiteHeader>
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
                user: null,
            }
        },
        watch: {
            $route() {
                const userJson = window.getCookie('user');
                if (userJson) {
                    this.user = JSON.parse(userJson);
                } else {
                    this.user = 'Вы не авторизованы';
                }
            }
        }, 
        created() {
            const userJson = window.getCookie('user');
            if (userJson) {
                this.user = JSON.parse(userJson);
            } else {
                this.user = {};
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
