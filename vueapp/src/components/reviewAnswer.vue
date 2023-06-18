<template>
    <div v-if="user">
        <div> {{ user.name }} </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        props: {
            user: Object,
        }
    });
</script>   