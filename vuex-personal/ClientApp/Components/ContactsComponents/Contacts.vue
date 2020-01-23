<template>
  <div>
    <!-- In the entry vue file, the template used MUST be enclosed within div's -->
    <h1>Manage Contacts</h1>
    <!-- Below is a prop. This needs to match the value in the data object => greetingsListings. The v-bind is the new property to use in the child file; props: ['greetings'] -->
    <greeting-component v-bind:greetings="greetingsListings"></greeting-component>
    <br />
    <button type="button" class="btn btn-primary" v-on:click="insert()"> Add Contact </button>
    <br />
    <table class="table table-striped">
      <thead>
        <tr>
          <th> First Name </th>
          <th> Surname </th>
          <th> Age </th>
          <th> Gender </th>
          <th> Projects </th>
          <th> </th>
          <th> </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(contact, index) in contacts">
          <td>
            <input v-model="contact.firstName" :disabled="!contact.isEditable" />
            <!-- A div-error class is required for each of the model properties stating the error message output; ** VERY IMPORTANT ** -->
            <div class="error" v-if="!$v.contacts.$each[index].firstName.required"> Required </div>
          </td>
          <td>
            <input v-model="contact.surname" :disabled="!contact.isEditable" />
            <div class="error" v-if="!$v.contacts.$each[index].surname.required"> Required </div>
          </td>
          <td>
            <input v-model="contact.age" :disabled="!contact.isEditable" />
            <div class="error" v-if="!$v.contacts.$each[index].age.required"> Required </div>
            <div class="error" v-if="!$v.contacts.$each[index].age.numeric"> Numeric only </div>
            <div class="error" v-if="!$v.contacts.$each[index].age.between"> Age ranges from 0-120 </div>
          </td>
          <td>
            <select v-model="contact.gender" :disabled="!contact.isEditable">
              <option v-for="gender in genderOptions" v-bind:value="gender">
                {{ gender }}
              </option>
            </select>
            <div class="error" v-if="!$v.contacts.$each[index].gender.required"> Required </div>
          </td>
          <td>
            <multiselect v-model="contact.projects" :options="projects" :multiple="true" :disabled="!contact.isEditable"> </multiselect>
          </td>
          <td>
            <button v-if="!contact.isEditable" type="button" class="btn btn-warning" v-on:click="edit(index)"> Edit </button>
            <button v-else type="button" class="btn btn-warning" v-on:click="edit(index)"> Done </button>
          </td>
          <td> <button type="button" class="btn btn-danger" v-on:click="remove(index)"> Delete </button></td>
        </tr>
      </tbody>
    </table>
    <input type="button" class="btn btn-success btn-lg" v-on:click="submitForm" value="Save" id="button-save" />
  </div>
</template>


<script>
  import { mapGetters } from 'vuex';
  import { required, numeric, between } from 'vuelidate/lib/validators'  // you need to define what validators you required here
  import Greeting from './Greeting'

  export default {
    name: "ContactsPage",

    // Define additional components to bring into this vue file; Greeting.vue
    components: {
      // this is where other components from other .vue files would normally go
      // e.g. help_section: "help-section" <!-- then this would be the html
      "greeting-component": Greeting
    },

    // Computed properties are able to process and even modify getters or locally stored Data().
    // Computed properties are cached until their values change. Methods do not cache data but are generated once
    // When values are prone to change use computer properties to retrieve data rather than methods and methods will not change the value of the retrieved data
    computed: {
      ...mapGetters({
        contacts: "getContactData"
      })
    },

    // validation object here is required to specify the array of objects which needs validating
    // $each refers to each in the array
    // required on the 'firstName' property means it is needed
    validations: {
      contacts: {
        $each: {
          firstName: { required },
          surname: { required },
          age: {
            required,
            numeric,
            between: between(0, 120)
          },
          gender: { required }
        }
      }
    },


    // Refers to constant data on the page. This data can never be modified
    // Props would be used if the projects array data listed below was required on multiple componenets, thus re-using code and not having static data on each page in the data object
    // Both data and functions/methods can be passed in props
    data() {
      return {
        genderOptions: ["Male", "Female"],
        projects: ["CEO Survey", "Clearing House", "TOV-Product", "TOV-Spacy", "British Gas", "Dynamic"],
        greetingsListings: ["Good Afternoon", "Good Evening", "Good Morning"] // This is a prop. Data is sent from the parent (current .vue file) to the child (Greetings.vue file) 
      }
    },

    // Mounted loads when the page loads
    mounted() {
      this.$store.dispatch("loadContactData");
    },

    methods: {
      submitForm() {
        this.$v.$touch();

        if (this.$v.$invalid) {
          alert("Failed submission")
        } else {
          alert("Successful submission");
          this.$store.dispatch("saveContactData");   // during a dispatch, the entirity of the state is passed to the action
        }
      },

      edit: function (contact_index) {
        !this.contacts[contact_index].isEditable ? this.contacts[contact_index].isEditable = true : this.contacts[contact_index].isEditable = false;
      },

      remove: function (contact_index) {
        this.contacts.splice(contact_index, 1);
      },

      insert() {
        let obj = { firstName: "", surname: "", age: "", gender: "", isEditable: true, projects: []};
        this.contacts.push(obj);
      }

      // # This is an example of how to get access to a global mixin
      //daysOfWeek() {
      //  return this.daysOfWeekFromMixin;
      //}
    }
  }
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

  .error {
    color: red;
  }

  #button-save {
    float:right;
  }

</style>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>
