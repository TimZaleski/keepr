import { AppState } from '../AppState'

export const closeModals = () => {
  AppState.showModal = false
  AppState.showKeep = false
  AppState.showAddKeep = false
  AppState.showAddVault = false
}
