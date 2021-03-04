import { AppState } from '../AppState'
import { api } from './AxiosService'
import { profileService } from '../services/ProfileService'

const baseURL = '/api/keeps/'

class KeepService {
  async getAllKeeps() {
    const res = await api.get(baseURL)
    AppState.keeps = res.data
  }

  async getKeep(keepId) {
    const res = await api.get(baseURL + keepId)
    AppState.activeKeep = res.data
    AppState.showModal = true
    AppState.showKeep = true
  }

  async getKeepsByVaultId(vaultId) {
    const res = await api.get('/api/vaults/' + vaultId + '/keeps')
    AppState.keeps = res.data
  }

  async createKeep(data) {
    await api.post(baseURL, data)
    profileService.getKeepsByProfileId(AppState.account.id)
  }

  async editKeep(data, keepId) {
    await api.put(baseURL + keepId, data)
    this.getKeep(keepId, true)
  }

  async deleteKeep(groupId) {
    await api.delete(baseURL + groupId)
    AppState.activeKeep = null
    this.getAllKeeps()
  }
}

export const keepService = new KeepService()
