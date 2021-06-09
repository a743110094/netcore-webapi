import Vue from 'vue'
import App from './App.vue'
import Element from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css';
import Pagination from "@/components/Pagination";

Vue.use(Element)
Vue.config.productionTip = false
Vue.component('Pagination', Pagination)

new Vue({
  render: h => h(App),
}).$mount('#app')
