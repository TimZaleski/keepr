<template lang="">
  <div class="keep"
       :style="`background: linear-gradient( rgba(0, 0, 0, 0), rgba(0, 0, 0, 0.6)), url('${keep.img}') no-repeat center center /cover; overflow-y: hidden`"
  >
  <img :src="keep.img" class="hdnImg" alt="...">
    <div class="keep-darken"></div>
    <div class="keep-content">
      <h3 class="keep-name keepTxt">
        {{ keep.name }}
      </h3>
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
.keep{
  border-radius: 5px;
  max-height: 26em;
}

.hdnImg{
  visibility: hidden;
  max-height: 20em;
}

.keepTxt{
  color:rgb(216, 216, 216)
}
</style>
