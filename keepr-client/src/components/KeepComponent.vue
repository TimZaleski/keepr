<template lang="">
  <div class="keep"
       :style="`background: linear-gradient( rgba(0, 0, 0, 0), rgba(0, 0, 0, 0.6)), url('${keep.img}') no-repeat center center /cover; overflow-y: hidden`"
       @click="showKeepInfo"
  >
  <img :src="keep.img" class="hdnImg" alt="...">
    <div class="keep-darken"></div>
    <div class="keep-content bottomContainer">
      <h3 class="keep-name keepTxt">
        {{ keep.name }}
      </h3>
      <i class="fa fa-user profImg"></i>
    </div>
  </div>
</template>
<script>
import { useRouter } from 'vue-router'
import { closeModals } from '../utils/Modal'
import { keepService } from '../services/KeepService'
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const router = useRouter()
    const showKeepInfo = () => {
      keepService.getKeep(props.keep.id)
    }
    const travel = () => {
      router.push('/keep/' + props.keep.id)
      closeModals()
    }
    return {
      showKeepInfo,
      travel
    }
  }
}
</script>
<style scoped>
.keep{
  border-radius: 5px;
  max-width: 100%;
  height: auto;
}

.hdnImg{
  visibility: hidden;
  max-width: 100%;
  height: auto;
}

.keepTxt{
  color:rgb(216, 216, 216);
  margin: 1em
}

.profImg{
  width: 50px;
  height: 50px;
  background-color: rgb(65, 65, 65);
  color: turquoise;
  border: none;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  cursor: pointer;
  font-size: 20px;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  margin: 1em
}

.bottomContainer{
  display: flex;
  justify-content: space-between;
}

</style>
