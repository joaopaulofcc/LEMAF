import Vue from 'vue'
import './plugins/vuetify'
import App from './App.vue'
import router from './router'

import { library } from '@fortawesome/fontawesome-svg-core'
import { faMapMarkerAlt, faCalendarAlt, faUserAlt, faCrown, faCreditCard } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'


library.add(faMapMarkerAlt)
library.add(faCalendarAlt)
library.add(faUserAlt)
library.add(faCrown)
library.add(faCreditCard)

Vue.component('font-awesome-icon', FontAwesomeIcon)

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
  router
}).$mount('#app')
