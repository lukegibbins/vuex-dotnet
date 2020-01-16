// # Main JS file used to initialise Vue
// # This will be the entry bundle point for webpack to bundle

import vue from "vue";
import store from "../Stores/ContactsStore";
import components from "../Components/ContactsComponents/Contacts.vue";

// why are we defining properties in the Vue object? Where are they getting reference in the proj
new vue({
  el: '#app',
  store,
  render: r => r(components)
})
