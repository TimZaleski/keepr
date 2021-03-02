<template lang="">
  <div class="keep"
       :style="`background: linear-gradient( rgba(0, 0, 0, 0.6), rgba(0, 0, 0, 0)), url('${keep.img}') no-repeat center center /cover; overflow-y: hidden`"
  >
    <div class="keep-darken"></div>
    <div class="keep-content">
      <h3 class="keep-name">
        {{ keep.name }}
      </h3>
      <p class="keep-description m-0 p-0">
        {{ keep.description }}
      </p>
    </div>
  </div>
</template>
<script>
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  }
}
</script>
<style scoped>
</style>