import { AppState } from '../AppState'

export const closeModals = () => {
  AppState.showModal = false
  AppState.showGroupInfo = false
}
