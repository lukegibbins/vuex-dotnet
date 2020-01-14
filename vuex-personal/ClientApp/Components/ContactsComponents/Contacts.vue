<template>

  <h1>Manage contacts template</h1>
  <br />

  <greeting-section></greeting-section>

  <table class="table table-striped">
    <thead>
      <tr>
        <th> First name </th>
        <th> Surname </th>
        <th> Age</th>
        <th> Gender</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="contact in contacts">
        <td> {{ contact.firstName }} </td>
        <td> {{ contact.surname }} </td>
        <td> {{ contact.age }} </td>
        <td> {{ contact.gender }} </td>
      </tr>
    </tbody>
  </table>

</template>


<script>
  // component imports
  import Greeting from "./Greeting";

  export default {
    name: "ContactsPage",

    // Define additional components to bring into this vue file; Greeting.vue
    components: {
      "greeting-section:": Greeting
    },

    // Computed properties are able to process and even modify getters or locally stored Data().
    // Computed properties are cached until their values change. Methods do not cache data but are generated once
    // When values are prone to change use computer properties to retrieve data rather than methods and methods will not change the value of the retrieved data
    computed: {
      ...mapGetters({
        contacts: "getContactData"
      })
    },

    mounted() {
      this.$store.dispatch("loadContactData");
    },

    methods: {
      submitForm() {
            // here, the entireity of the state (state.contactData) is passed as a parameter in this method 
            this.$store.dispatch("saveContactData");
        }
    }
  };
</script>


<style>
  table {
  border: 2px solid #42b983;
  border-radius: 3px;
  background-color: #fff;
}

th {
  background-color: #42b983;
  color: rgba(255,255,255,0.66);
  cursor: pointer;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

td {
  background-color: #f9f9f9;
}

th, td {
  min-width: 120px;
  padding: 10px 20px;
}
</style>
