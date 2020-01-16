import axios from "axios";

export default {
  // Significance of the commit object?
  // it doesn't even get passed form the app.vue file?
  loadContactData({ commit }) {
    axios.get("/Contacts/GetContacts").then(response => {
      console.log("Current state => ", response);
      commit("setContactData", response.data);
    })
    .catch(error => {
        console.error("Error getting contact data from request.", error)
      });
  },

  saveContactData({ state }) {
    alert("You've reached me!");
    console.log("Changed state => ", state.contactData);    //when logging to console, if a parameter is needed use a comma to separate.


    //axios request
  }
};
