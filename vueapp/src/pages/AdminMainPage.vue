<template>
    <div class="container">
        <h1>Панель администратора</h1>
        <div class="admin-page">
            <div class="admin-page__users-table">
                <table>
                    <thead>
                        <tr>
                            <th>
                                Сотрудник
                            </th>
                            <th>
                                Балл
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="user in users" :key="user.id">
                            <td>
                                {{ user.name}}
                            </td>
                            <td>
                                {{ user.score}}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                users: null,
            };
        },
        created() {
            this.fetchUsers();
        },
        methods: {
            fetchUsers() {
                this.users = [
                    {
                        id:1,
                        name: 'Володя',
                        score: 12,
                    },
                    {
                        id:2,
                        name: 'Петя',
                        score: 42,
                    },
                ]
            },
        },
    });
</script>

<style>
    .admin-page {
        display: grid;
        grid-template-columns: 65% 35%;
    }

    .admin-page__users-table table {
        width: 100%;
        background: #F5F5F5;
        border: 2px solid rgba(15, 34, 34, 0.15);
    }

    .admin-page__users-table table tr {
        border: 2px solid rgba(15, 34, 34, 0.15);
    }

    .admin-page__users-table table td {
        text-align: center;
    }
</style>