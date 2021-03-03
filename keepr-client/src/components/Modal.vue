<template>
  <div id="myModal-screen"
       class="d-flex justify-content-center py-5"
       :class="{'show': showModal, 'hide': !showModal}"
  >
    <div id="myModal-clickoff" @click="closeModals"></div>
    <div id="myModal-container">
      <!-- Insert all modal components here with their respective v-if's -->
      <modal-keep v-if="modalChoice.showKeep"></modal-keep>
      <modal-add-keep v-if="modalChoice.showAddKeep"></modal-add-keep>
      <modal-add-vault v-if="modalChoice.showAddVault"></modal-add-vault>
    </div>
  </div>
</template>
<script>
import { computed, reactive } from 'vue'
import ModalKeep from './ModalKeep.vue'
import ModalAddKeep from './ModalAddKeep.vue'
import ModalAddVault from './ModalAddVault.vue'
import { AppState } from '../AppState'
import { closeModals } from '../utils/Modal'
export default {
  components: { ModalKeep, ModalAddKeep, ModalAddVault },
  setup() {
    const showModal = computed(() => AppState.showModal)
    const modalChoice = reactive({
      showKeep: computed(() => AppState.showKeep),
      showAddKeep: computed(() => AppState.showAddKeep),
      showAddVault: computed(() => AppState.showAddVault)
    })
    // const close = closeModals()
    return {
      showModal,
      modalChoice,
      closeModals
    }
  }
}
</script>
<style scoped>
@import "../assets/css/modals.css";
</style>
