export default {
  // how is it even getting access to the state?
  // is the payload the parameter passed from the mutator
  setContactData(state, payload) {
    console.log("mutator has been reached");
    state.contactData = payload;
  }
}
