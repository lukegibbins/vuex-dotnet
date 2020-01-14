// # index.js is used to define all the stores files
import Vue from "vue";
import Vuex from "vuex";

import state from "./state";
import getters from "./getters";
import actions from "./actions";
import mutators from "./mutators";

Vue.use(Vuex);

const store = new Vuex.Store({
  state,
  getters,
  mutators,
  actions
});

export default store;
