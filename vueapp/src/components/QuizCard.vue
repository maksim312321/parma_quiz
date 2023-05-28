<template>
    <div>
        <div> {{ title }} </div>
        <van-button type="primary">Primary</van-button>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        props: {
            title: String,
        },
    });
</script>