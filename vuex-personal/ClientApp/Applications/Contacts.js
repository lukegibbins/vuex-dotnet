// # Main JS file used to initialise Vue
// # This will be the entry bundle point for webpack to bundle

import Vue from "vue";
import Store from "../Stores/ContactsStore"
import Components from "../Components/ContactsComponents/Contacts.vue"

// why are we defining properties in the Vue object? Where are they getting reference in the proj
new Vue({
  el: "#app",
  Store,
  render: r => r(Components)
})
