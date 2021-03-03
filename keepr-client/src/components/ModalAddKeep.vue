<template>
  <div class="myModal-content">
    <div class="myModal-frame dark-scrollbar">
      <div class="row">
        <div class="col-12 text-center">
          <h1>New Keep</h1>
        </div>
        <div class="col-12 my-1">
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
        <div class="col-12 my-1">
          <label for="img">Image Url</label><br>
          <div class="form-group">
            <input v-model="form.img"
                   type="text"
                   class="form-control"
                   name="img"
                   id="img"
                   aria-describedby="helpId"
                   placeholder="URL..."
            >
          </div>
        </div>
        <div class="col-12 my-1">
          <label for="description">Description</label><br>
          <div class="form-group">
            <input v-model="form.description"
                   type="text"
                   class="form-control"
                   name="description"
                   id="description"
                   aria-describedby="helpId"
                   placeholder="Keep Description..."
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
import { keepService } from '../services/KeepService'
import { closeModals } from '../utils/Modal'
export default {
  setup() {
    const form = reactive({
      name: '',
      description: '',
      img: ''
    })
    const create = () => { keepService.createKeep(form); closeModals() }
    return { form, create }
  }
}
</script>
<style scoped>
@import "../assets/css/modals.css";
</style>
