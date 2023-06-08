import App from './App.vue'
import { Button, Popup, Loading } from 'vant';
import { createApp } from 'vue'
import router from './router/router.js'
import 'vant/lib/index.css';
createApp(App)
    .use(Button)
    .use(Popup)
    .use(router)
    .use(Loading)
    .mount('#app');
