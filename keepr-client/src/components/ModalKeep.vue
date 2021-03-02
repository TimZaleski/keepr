<template>
  <div class="myModal-content">
    <div class="myModal-frame dark-scrollbar">
      <div class="myModal-image"
           :src="keep.img"
           :style="`background: linear-gradient( rgba(0, 0, 0, 0), rgba(0, 0, 0, 0.5)), url('${keep.img}') no-repeat center center /cover; overflow-y: hidden`"
      ></div>
      <h1>{{ keep.name }}</h1>
      <p class="m-0 p-0">
        {{ keep.description }}
      </p>
    </div>
  </div>
</template>
<script>
import { computed } from 'vue'
import { AppState } from '../AppState'

export default {
  setup() {
    const keep = computed(() => AppState.activeKeep)
    return { keep }
  }
}
</script>
<style scoped>
@import "../assets/css/modals.css";
#button-accept {
  background-color: rgb(153, 255, 0);
}
#button-decline {
  background-color: rgb(251, 92, 92)
}
</style>
