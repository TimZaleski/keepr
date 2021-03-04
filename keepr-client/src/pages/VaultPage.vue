<template>
  <div class="profilePage container-fluid">
    <div class="row mt-3">
      <div class="col-12">
        <div class="row">
          <div class="col">
            <h1>{{ state.vault.name }} <span class = "pointMe"><i class="fa fa-trash" v-if="state.account.id == state.vault.creatorId" @click="deleteVault"></i> </span></h1>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h2>Keeps: {{ state.keeps.length }}</h2>
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
import { keepService } from '../services/KeepService'
import { vaultService } from '../services/VaultService'
import { AppState } from '../AppState'
import { closeModals } from '../utils/Modal'
import { logger } from '../utils/Logger'
export default {
  name: 'ProfilePage',
  setup() {
    const router = useRoute()
    const state = reactive({
      profile: computed(() => AppState.searchedProfile),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vault: computed(() => AppState.activeVault)
    })
    const deleteVault = async() => {
      if (confirm('Delete this Vault?')) {
        await vaultService.deleteVault(AppState.activeVault.id)
        closeModals()
        useRoute().push('/profiles/' + AppState.account.id)
      }
    }
    onMounted(() => {
      logger.log('vault page mounted' + router.params.id)
      keepService.getKeepsByVaultId(router.params.id)
      logger.log('vault keeps gotten' + router.params.id)
      vaultService.getVault(router.params.id)
      logger.log('vault gotten' + router.params.id)
    })
    return { state, deleteVault }
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
.pointMe{
  cursor: pointer;
}
</style>
