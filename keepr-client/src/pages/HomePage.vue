<template>
  <div
    id="home"
    class="masonry-container"
  >
      <div class="masonry-item" v-for="keep in keeps" :key="keep.id">
        <keep-component :keep="keep"></keep-component>
      </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { keepService } from '../services/KeepService'
import { AppState } from '../AppState'
import KeepComponent from '../components/KeepComponent.vue'
export default {
  components: { KeepComponent },
  name: 'Home',
  setup() {
    onMounted(() => {
      keepService.getAllKeeps()
    })
    const keeps = computed(() => AppState.keeps)
    return { keeps }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}

.masonry-container {
 column-count: 4;
 column-gap: 1em;
}
.masonry-item {
 display: inline-block;
 width: 100%;
 margin: 1em 0 1em;
}
</style>
