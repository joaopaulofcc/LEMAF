import Vue from 'vue'
import VueRouter from 'vue-router'
import Travels from '@/components/Travels'

Vue.use(VueRouter)

export default new VueRouter({
    routes: [
     {
        path: '/',
        name: 'Travels',
        component: Travels
      }
    ]
  })