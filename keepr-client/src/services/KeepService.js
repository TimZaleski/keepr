import { AppState } from '../AppState'
import { api } from './AxiosService'
import { profileService } from '../services/ProfileService'
import { logger } from '../utils/Logger'
const baseURL = '/api/keeps/'

class KeepService {
  async getAllKeeps() {
    AppState.keeps = null
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
    AppState.keeps = null
    logger.log('KEEPS RESET')
    const res = await api.get('/api/vaults/' + vaultId + '/keeps')
    logger.log('KEEPS RETURNED')
    AppState.keeps = res.data
    logger.log(res.data)
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
