<template>
  <div class="myModal-content">
    <div class="myModal-frame dark-scrollbar container-fluid">
      <div class="row">
        <div class="col-6">
          <img :src="keep.img" class="hdnImg">
        </div>
        <div class="col-6 parent">
          <div class="row d-flex">
            <div class="col-12 d-flex spaceOut">
              <span><i class="fa fa-eye"></i> {{ keep.views }} </span>
              <span><i class="fab fa-kickstarter"></i> {{ keep.keeps }} </span>
              <span><i class="fa fa-share-alt"></i> {{ keep.shares }} </span>
            </div>
          </div>
          <div class="row">
            <div class="col-12 d-flex titl">
              <h1>{{ keep.name }}</h1>
            </div>
          </div>
          <div class="row">
            <div class="col">
              <p class="m-0 p-0">
                {{ keep.description }}
              </p>
            </div>
          </div>
          <div class="child d-flex spaceOut">
            <span>Add To Vault <select name="addToVault" id="addToVault" class="ddl" v-model="selected" @change="onChange($event)">
                <option v-for="vault in myVaults" v-bind:value="vault.id" :key="vault.id">
                    {{vault.name}}
                </option></select>
            </span>
            <span class = "pointMe"><i class="fa fa-trash" v-if="act.id == keep.creatorId" @click="deleteKeep"></i> </span>
            <span class="pointMe" @click="travel">{{ keep.creator.name }} </span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { keepService } from '../services/KeepService'
import { closeModals } from '../utils/Modal'
import { useRouter } from 'vue-router'
import { vaultKeepService } from '../services/VaultKeepService'
export default {
  setup() {
    const router = useRouter()
    const keep = computed(() => AppState.activeKeep)
    const myVaults = computed(() => AppState.myVaults)
    const act = computed(() => AppState.account)
    const deleteKeep = async() => {
      if (confirm('Delete this Keep?')) {
        keepService.deleteKeep(AppState.activeKeep.id)
        closeModals()
      }
    }
    const travel = () => {
      router.push('/profiles/' + AppState.activeKeep.creatorId)
      closeModals()
    }
    const onChange = (event) => {
      vaultKeepService.createVaultKeep(event.target.value, AppState.activeKeep.id)
      closeModals()
    }
    return { keep, myVaults, act, deleteKeep, travel, onChange }
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
.hdnImg{
  height: auto;
  width: 100%;
}
.spaceOut{
  justify-content: space-between;
}
.titl{
  justify-content: center;
  align-items: center;
}
.parent {
  display: flex;
  flex-direction: column;
}
.child {
  margin-top: auto;
}
.pointMe{
  cursor: pointer;
}
</style>
