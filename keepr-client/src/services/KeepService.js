import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

const baseURL = '/api/keeps/'

class KeepService {
  async getAllKeeps() {
    const res = await api.get(baseURL)
    logger.log(res.data)
    AppState.keeps = res.data
  }

  async getKeep(keepId) {
    const res = await api.get(baseURL + keepId)
    AppState.activeKeep = res.data
  }

  async create(data) {
    const res = await api.post(baseURL, data)
    AppState.activeKeep = res.data
  }

  async editKeep(data, keepId) {
    await api.put(baseURL + keepId, data)
    this.getKeep(keepId, true)
  }

  async deleteKeep(groupId) {
    await api.delete(baseURL + groupId)
  }
}

export const keepService = new KeepService()
