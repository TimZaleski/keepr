<template lang="">
  <div class="vault"
       :style="`overflow-y: hidden`"
       @click="showVaultInfo"
  >
    <div class="vault-darken"></div>
    <div class="vault-content bottomContainer">
      <h3 class="vault-name vaultTxt">
        {{ vault.name }}
      </h3>
    </div>
  </div>
</template>
<script>
import { useRouter } from 'vue-router'
import { closeModals } from '../utils/Modal'
export default {
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const router = useRouter()
    const travel = () => {
      router.push('/vault/' + props.vault.id)
      closeModals()
    }
    return {
      travel
    }
  }
}
</script>
<style scoped>
.vault{
  border-radius: 5px;
  max-width: 100%;
  height: auto;
  background-color: rgb(114, 139, 143);
  cursor: pointer;
}

.hdnImg{
  visibility: hidden;
  max-width: 100%;
  height: auto;
}

.vaultTxt{
  color:rgb(0, 0, 0);
  margin: 1em
}

.bottomContainer{
  display: flex;
  justify-content: space-between;
}

</style>
