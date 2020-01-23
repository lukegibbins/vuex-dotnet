// # index.js is used to define all the stores files
import Vue from "vue";
import Vuex from "vuex";
import Vuelidate from 'vuelidate';
import Multiselect from 'vue-multiselect';

// it is vitally important that these names are as they are. Vue will only recognise these names
import state from "./state";
import getters from "./getters";
import actions from "./actions";
import mutations from "./mutations";

Vue.use(Vuex);
Vue.use(Vuelidate);
Vue.component('multiselect', Multiselect);

// This is here to purely demonstrate the functionality of a mixin
// Mixins are used provide multiple components with the same data or functionality (this can also be a method which updates values in a component)
Vue.mixin({
  data() {
    return {
      daysOfWeekFromMixin: ["Mon", "Tuesday", "Wedneday", "Thur", "Friday", "Saturday", "Sunday"]
    }
  }
})

const store = new Vuex.Store({
  state,
  getters,
  mutations,
  actions
});

export default store;
