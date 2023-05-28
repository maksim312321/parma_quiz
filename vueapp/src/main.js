import App from './App.vue'
import { Button, Popup } from 'vant';  
import { createApp } from 'vue'
import router from './router/router.js'

import 'vant/lib/index.css';
createApp(App)
    .use(Button)
    .use(Popup)
    .use(router)
    .mount('#app');
