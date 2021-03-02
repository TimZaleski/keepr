/* eslint-disable */
<template>
  <header>
    <Navbar />
  </header>
  <main>
    <modal></modal>
    <router-view v-slot="{Component}">
      <transition name="route" mode="out-in">
        <component :is="Component" />
      </transition>
    </router-view>
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Modal from './components/Modal.vue'
export default {
  components: { Modal },
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

</style>
