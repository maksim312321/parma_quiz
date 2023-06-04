<template>
    <div>
        <div> {{ title }} </div>
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