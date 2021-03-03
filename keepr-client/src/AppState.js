import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  vaults: [],
  myVaults: [],
  activeVault: {},
  activeKeep: {},
  keeps: [],
  searchedProfile: {},
  showModal: false,
  showKeep: false,
  showAddKeep: false,
  showAddVault: false
})
