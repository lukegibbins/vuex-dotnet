// # index.js is used to define all the stores files
import Vue from "vue";
import Vuex from "vuex";
import Vuelidate from 'vuelidate';

// it is vitally important that these names are as they are. Vue will only recognise these names
import state from "./state";
import getters from "./getters";
import actions from "./actions";
import mutations from "./mutations";

Vue.use(Vuex);
Vue.use(Vuelidate);

const store = new Vuex.Store({
  state,
  getters,
  mutations,
  actions
});

export default store;
