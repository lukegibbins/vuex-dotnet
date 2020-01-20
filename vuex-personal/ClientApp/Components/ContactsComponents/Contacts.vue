<template>
  <div>
    <!-- In the entry vue file, the template used MUST be enclosed within div's -->
    <h1>Manage Contacts</h1>
    <br />
    <button type="button" class="btn btn-primary" v-on:click="insert()"> Add Contact </button>
    <br />
    <table class="table table-striped">
      <thead>
        <tr>
          <th> First Name </th>
          <th> Surname </th>
          <th> Age</th>
          <th> Gender</th>
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
                {{gender}}
              </option>
            </select>
            <div class="error" v-if="!$v.contacts.$each[index].gender.required"> Required </div>
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

  export default {
    name: "ContactsPage",

    // Define additional components to bring into this vue file; Greeting.vue
    components: {
      // this is where other components from other .vue files would normally go
      // e.g. help_section: "help-section" <!-- then this would be the html
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

    data() {
      return {
        genderOptions: ["Male", "Female"]
      }
    },

    mounted() {
      this.$store.dispatch("loadContactData");
    },

    methods: {
      submitForm() {
        // here, the entirity of the state (state.contactData) is passed as a parameter in this method
        this.$v.$touch();

        if (this.$v.$invalid) {
          alert("Failed submission")
        } else {
          alert("Successful submission");
          this.$store.dispatch("saveContactData");
        }         
      },

      edit: function (contact_index) {   
        !this.contacts[contact_index].isEditable ? this.contacts[contact_index].isEditable = true : this.contacts[contact_index].isEditable = false;
      },

      remove: function (contact_index) {
        this.contacts.splice(contact_index, 1);
      },

      insert() {
        let obj = { firstName: "", surname: "", age: "", gender: "", isEditable: true };
        this.contacts.push(obj);
      }
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

#button-save {
  float:right;
}

.error {
  color:red;
}
</style>
