<template>
  <header>
    <Navbar />
  </header>
  <RouterView />
</template>

<script>
import { RouterLink, RouterView } from "vue-router";
import Navbar from "./views/Navbar.vue";

export default {
  name: "app",
  components: {
    Navbar,
  },
};
</script>

