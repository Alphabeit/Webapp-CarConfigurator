<!--
created:    20260422 / alphabeit
lastupdate: 20260428 / alphabeit

See also https://vuetifyjs.com/en/components/buttons/ for ref.
See also https://www.codestudy.net/blog/open-link-in-new-window-with-vuetify-v-btn-and-vue-router/ for ref.
-->

<template>

  <section class="cards-wrapper">
    
    <div class="card-grid-space">
      <a class="card" @click="openRoute('/build')">
        <div>
          <h1>Build</h1>
          <p>Start to building your "dream" car.</p>
        </div>
      </a>
    </div>

    <div class="card-grid-space">
      <a class="card" @click="openRoute('/order')">
        <div>
          <h1>Order</h1>
          <p>Shown your order.</p>
        </div>
      </a>
    </div>

    <div class="card-grid-space">
      <a class="card" @click="openRoute('/about')">
        <div>
          <h1>About</h1>
          <p>About this website.</p>
        </div>
      </a>
    </div>

  </section>

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
