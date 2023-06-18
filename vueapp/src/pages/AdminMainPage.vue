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
                        <tr @click="selectUser(user)" class="user__row" v-for="user in users" :key="user.id">
                            <td>
                                {{ user.name}} {{ user.surname }}
                            </td>
                            <td>
                                {{ user.correctAnswers }} / {{ questionsCount }}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <ReviewAnswer :user="selectedUser"></ReviewAnswer>   
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import ReviewAnswer from '../components/ReviewAnswer.vue';

    export default defineComponent({
        components: {
            ReviewAnswer,
        },
        data() {
            return {
                users: null,
                questionsCount: null,
                selectedUser: null,
            };
        },
        created() {
            this.fetchUsers();
        },
        methods: {
            selectUser(user) {
                console.log(user.name);
                this.selectedUser = user;
            },
            async fetchUsers() {
                let res;
                await fetch(`https://localhost:7202/api/users`)
                    .then(response => response.json())
                    .then(response => { res = response });
                this.users = res;

                this.fetchUsersScore()
            },
            async fetchUsersScore() {
                let res;
                await fetch('https://localhost:7202/question/all')
                    .then(response => response.json())
                    .then(response => { res = response });
                this.questionsCount = res.length;


                for (let user of this.users) {
                    let userRes;
                    try {
                        await fetch(`https://localhost:7202/api/userAnswers/${user.id}`)
                            .then(response => response.json())
                            .then(response => { userRes = response });
                    }
                    catch (e) {
                        console.log(`failed to load score ${user.name}`, e);
                        continue;
                    }

                    user.correctAnswers = 0;
                    user.reviewAnswers = 0;
                    userRes.forEach(item => {
                        if (item.isCorrect) {
                            user.correctAnswers++;
                        }
                        if (item.isCorrect === null) {
                            user.reviewAnswers++;
                        }
                    });
                }
            }
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

    .user__row {
        cursor: pointer;
    }

        .user__row:hover {
            background: #dfdfdf;
        }
</style>