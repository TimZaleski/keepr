<template>
  <div class="profilePage container-fluid">
    <div class="row mt-3">
      <div class="col text-center">
        <img :src="state.profile.picture" alt="">
        <h2>
          Welcome To {{ state.profile.name }}'s Page
        </h2>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h4>Vaults</h4>
      </div>
      <vault-component v-for="v in state.vaults" :key="v" :review-prop="v" />
    </div>
    <div class="row">
      <div class="col-12">
        <h4>Keeps</h4>
      </div>
      <keep-component v-for="k in state.keeps" :key="k" :review-prop="k" />
    </div>
  </div>
</template>

<script>
import { onMounted, reactive, computed } from 'vue'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'
import { AppState } from '../AppState'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      profile: computed(() => AppState.searchedProfile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)
    })
    onMounted(() => {
      profileService.getProfileById(route.params.id)
      profileService.getKeepsByProfileId(route.params.id)
      profileService.getVaultsByProfileId(route.params.id)
    })
    return { state }
  }
}
</script>

<style scoped>
</style>