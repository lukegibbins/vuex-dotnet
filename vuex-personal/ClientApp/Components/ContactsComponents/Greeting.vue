<template>

  <h3>Good {{GetGreetingFromTime}},</h3>

</template>

<script>
  export default {
    name: "Greeting",

    methods: {
      GetGreetingFromTime() {
        var today = new Date();
        var curHr = today.getHours();

        if (curHr < 12) {
          return "morning";
        } else if (curHr < 18) {
          return "afternoon";
        } else {
          return "evening";
        }
      }
    }

  }
</script>
