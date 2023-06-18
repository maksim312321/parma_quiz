import MainPage from '../pages/MainPage'
import { createRouter, createWebHistory } from 'vue-router'
import QuizPage from '../pages/QuizPage.vue';
import QuizFinalPage from '../pages/QuizFinalPage.vue';
import AdminMainPage from '../pages/AdminMainPage.vue';
import AuthPage from '../pages/AuthPage.vue';

const routes = [
    {
        path: '/',
        name: 'main',
        component: MainPage,
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
        name: 'admin_main_page',
        component: AdminMainPage,
        beforeEnter(to, from, next) {
            const isAuthenticated = !!window.getCookie('user');
            if (isAuthenticated) {
                const user = JSON.parse(window.getCookie('user'));
                if (user.role == '2') {
                    next()
                } else {
                    next({ name: 'main' })
                }
            } else {
                next({ name: 'login' })
            }
        }
    },
    {
        path: '/login',
        name: 'login',
        component: AuthPage,
    }
]

const router = createRouter({
    routes,
    history: createWebHistory(process.env.BASE_URL)
});

router.beforeEach((to, from, next) => {
    const isAuthenticated = !!window.getCookie('user');
    if (to.name !== 'login' && !isAuthenticated) next({ name: 'login' })
    else next()
})

export default router;