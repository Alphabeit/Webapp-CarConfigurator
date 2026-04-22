<!--
created:    20260422 / alphabeit
lastupdate: 20260422 / alphabeit

See also https://vuetifyjs.com/en/components/buttons/ for ref.
See also https://www.codestudy.net/blog/open-link-in-new-window-with-vuetify-v-btn-and-vue-router/ for ref.
-->

<template>
  <h1>Homepage</h1>
  <p>Time to configure...</p>

  <!-- Navigation -->
  <v-btn @click="openRoute('/build')" variant="plain">
    Build Car
  </v-btn> <br>
  <v-btn @click="openRoute('/order')" variant="plain">
    Load Order
  </v-btn> <br>
  <v-btn @click="openRoute('/about')" variant="plain">
    About
  </v-btn> <br>
</template>

<script>
  export default {
    methods: {
      openRoute(route) {
        // Resolve the route to a full URL
        const { href } = this.$router.resolve(route);
        // Open in new window with security attributes
        window.open(href, '_self', 'noopener,noreferrer');
      },
    },
  };
</script>
