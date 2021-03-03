<template>
  <div class="profilePage container-fluid">
    <div class="row mt-3">
      <div class="col-3">
        <img :src="state.profile.picture" alt="">
      </div>
      <div class="col-9">
        <div class="row">
          <div class="col">
            <h3>Vaults: {{ state.vaults.length }}</h3>
            <h3>Keeps: {{ state.keeps.length }}</h3>
          </div>
        </div>
        <h1>
          {{ state.profile.name }}
        </h1>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h2>Vaults <span class="addGreen" v-if="state.account.id == state.profile.id" @click="addVault">+</span></h2>
      </div>
      <div
        class="masonry-container"
      >
          <div class="masonry-item" v-for="vault in state.vaults" :key="vault.id">
            <vault-component :vault="vault"></vault-component>
          </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h2>Keeps <span class="addGreen" v-if="state.account.id == state.profile.id" @click="addKeep">+</span></h2>
      </div>
      <div
        class="masonry-container"
      >
          <div class="masonry-item" v-for="keep in state.keeps" :key="keep.id">
            <keep-component :keep="keep"></keep-component>
          </div>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted, reactive, computed } from 'vue'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'
import { accountService } from '../services/AccountService'
import { AppState } from '../AppState'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      profile: computed(() => AppState.searchedProfile),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)
    })
    const addKeep = () => {
      AppState.showModal = true
      AppState.showAddKeep = true
    }
    const addVault = () => {
      AppState.showModal = true
      AppState.showAddVault = true
    }
    onMounted(() => {
      profileService.getProfileById(route.params.id)
      if (route.params.id === AppState.account.id) {
        accountService.getVaultsByAccountId(route.params.id)
      } else {
        profileService.getVaultsByProfileId(route.params.id)
      }
      profileService.getKeepsByProfileId(route.params.id)
    })
    return { state, addKeep, addVault }
  }
}
</script>

<style scoped>
.masonry-container {
  column-count: 4;
  column-gap: 3em;
  margin-left: 1em;
  margin-right: 1em;
}
.masonry-item {
  display: inline-block;
  width: 100%;
  margin: 1em 0 1em;
}
.addGreen {
  color: green;
}
</style>
