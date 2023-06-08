import MainPage from '../pages/MainPage'
import LoginPage from '../pages/LoginPage'
import { createRouter, createWebHistory } from 'vue-router'
import QuizPage from '../pages/QuizPage.vue';

const routes = [
    {
        path: '/',
        component: MainPage,
    },
    {
        path: '/login',
        component: LoginPage,
    },
    {
        path: '/quiz',
        component: QuizPage,
    }
]

const router = createRouter({
    routes,
    history: createWebHistory(process.env.BASE_URL)
});

export default router;