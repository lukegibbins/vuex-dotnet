import axios from "axios";

export default {
  // Significance of the commit object?
  // it doesn't even get passed form the app.vue file?
  loadContactData({ commit }) {
    axios.get("/Contacts/GetContacts").then(response => {
      console.log(response);
      commit("setContactData", response.data);
    })
    .catch(error => {
        console.error("Error getting contact data from request.", error)
      });
  },

  saveContactData({ currentState }) {

  }
};
