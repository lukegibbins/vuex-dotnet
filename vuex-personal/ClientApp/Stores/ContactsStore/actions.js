import axios from "axios";

export default {
  // commit objects refers to the entire state
  // it is passed in dispatches
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
    console.log("Changed state => ", state.contactData);    //when logging to console, if a parameter is needed use a comma to separate.
    axios.post("/Contacts/InsertOrUpdateContacts", state.contactData, {
        headers: {
          'Content-Type': 'application/json', // always specify headers on post requests
        }
      })
      .then((response) => {
        console.log("Successful submission", response);
        location.reload();
      }).catch(error => {
        console.error("Error inserting data", error);
      });
  }
};
