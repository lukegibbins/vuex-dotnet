export default {
  // how is it even getting access to the state?
  // is the payload the parameter passed from the mutator
  setContactData(state, payload) {
    state.contactData = payload;
  }
}
