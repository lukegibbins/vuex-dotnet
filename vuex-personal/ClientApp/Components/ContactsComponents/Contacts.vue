<template>

 <h1>Manage contacts template</h1>

</template>


<script>
  // package imports
  import Vue from "vue";
  import Axios from "axios";

  // component imports
  import Greeting from "./Greeting";

  export default {
    name: "ContactsPage",

    // Define additional components to bring into this vue file; Greeting.vue
    components: {
      "greeting-section:": Greeting
    },

    // Computed properties are able to process and even modify getters or locally stored Data().
    // Computed properties are cached until their values change. Methods do not cache data but are generated once.
    computed: {
      ...mapGetters({
        contacts: "getContactData"
      })
    },

    mounted() {
      this.$store.dispatch("loadContactData");
    }

    methods: {
      // submit/change data here
    }
  };

</script>
