<template>
  <div class="myModal-content">
    <div class="myModal-frame dark-scrollbar">
      <div class="row">
        <div class="col-12 text-center">
          <h1>New Vault</h1>
        </div>
        <div class="col-6 my-1">
          <label for="description">Name</label><br>
          <div class="form-group">
            <input v-model="form.name"
                   type="text"
                   class="form-control"
                   name="name"
                   id="name"
                   aria-describedby="helpId"
                   placeholder="Name..."
            >
          </div>
        </div>
        <div class="col-6 my-1">
          <label for="isPrivate">Private?</label><br>
          <div class="form-group">
            <input v-model="form.isPrivate"
                   type="checkbox"
                   class="form-control"
                   name="isPrivate"
                   id="isPrivate"
                   aria-describedby="helpId"
            >
          </div>
        </div>
      </div>
    </div>
    <div class="myModal-footer">
      <button id="myModal-button-join-group"
              class="myModal-button"
              @click="create"
      >
        Create
      </button>
    </div>
  </div>
</template>
<script>
import { reactive } from 'vue'
import { vaultService } from '../services/VaultService'
import { closeModals } from '../utils/Modal'
import { logger } from '../utils/Logger'
export default {
  setup() {
    const form = reactive({
      name: '',
      description: 'description',
      isPrivate: false
    })
    const create = () => { logger.log(form); vaultService.createVault(form); closeModals() }
    return { form, create }
  }
}
</script>
<style scoped>
@import "../assets/css/modals.css";
</style>
