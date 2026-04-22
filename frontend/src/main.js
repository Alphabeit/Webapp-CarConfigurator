// created:    20260421 / alphabeit
// lastupdate: 20260422 / alphabeit

// See also https://www.w3schools.com/vue/vue_routing.php as ref.
// See also https://vuetifyjs.com/en/getting-started/installation/#existing-projects as ref.

// globael style
import '../assets/main.css';

// libaries
import { createApp } from 'vue';
import { createRouter, createWebHistory } from 'vue-router';

import 'vuetify/styles';
import { createVuetify } from 'vuetify';
import * as components from 'vuetify/components';
import * as directives from 'vuetify/directives';

// Vue apps
import App   from "./App.vue";
import Home  from './components/Home.vue';
import Build from './components/Build.vue';
import Order from './components/Order.vue';
import About from './components/About.vue';

// create apps, set homepage
const app = createApp(App);

// add route to app
const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/',      component: Home },
        { path: '/build', component: Build },
        { path: '/order', component: Order },
        { path: '/about', component: About },
    ]
});

app.use(router);

// add vuetify to app
const vuetify = createVuetify({
  components,
  directives,
})
app.use(vuetify);

// start app
app.mount('#app');