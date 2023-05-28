<template>
    <div>
        Login Page
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                loading: false,
                post: null,
                testData: "testString",
                showPopup: false,
            };
        },
    });
</script>

<style>
</style>