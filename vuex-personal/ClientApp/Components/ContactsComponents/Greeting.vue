<template>
<div>
  <p><i id="greet"></i></p>
</div>
</template>

<script>
  export default {
    name: "GreetingsPage",

    props: ['greetings'], // This is the name of the bind property on the component it is passed from in the parent file

    mounted() {
      this.GetGreetingMessage();
    },

    methods: {
      GetGreetingMessage() {
        var message_id = document.getElementById("greet");
        var date = new Date();
        var hour = date.getHours();

        // Needed a reason to use props. This isn't the greatest of examples... :'(
        if (hour < 12) {
          message_id.innerHTML = this.$props.greetings[2]
        } else if (hour < 18) {
          message_id.innerHTML = this.$props.greetings[0]
        } else {
          message_id.innerHTML = this.$props.greetings[1]
        }
     }
   }
 }
</script>

<style>

</style>
