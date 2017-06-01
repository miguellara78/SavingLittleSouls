import Vue from 'vue';
import Element from 'element-ui'
import 'element-ui/lib/theme-default/index.css'
import 'font-awesome/css/font-awesome.css'
import '../../assets/my-elemet-ui.css'
import Login from './Login.vue';

Vue.use(Element);

new Vue({
  el: '#app',
  render: h => h(Login)
});