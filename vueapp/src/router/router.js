import MainPage from '../pages/MainPage'
import LoginPage from '../pages/LoginPage'
import { createRouter, createWebHistory } from 'vue-router'
import QuizPage from '../pages/QuizPage.vue';
import QuizFinalPage from '../pages/QuizFinalPage.vue';
import AdminMainPage from '../pages/AdminMainPage.vue';

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
    },
    {
        path: '/quiz_final',
        component: QuizFinalPage,
    },
    {
        path: '/admin_main_page',
        component: AdminMainPage,
    },
]

const router = createRouter({
    routes,
    history: createWebHistory(process.env.BASE_URL)
});

export default router;