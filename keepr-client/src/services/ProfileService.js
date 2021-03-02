import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

const baseURL = '/api/profiles/'

class ProfileService {

  async getProfileById(id) {
    const res = await api.get('api/profiles/' + id)
    AppState.searchedProfile = res.data
  }
  async getKeepsByProfileId(profileId) {
    const res = await api.get(baseURL + profileId + '/keeps')
    AppState.keeps = res.data
  }
  async getVaultsByProfileId(profileId) {
    const res = await api.get(baseURL + profileId + '/vaults')
    AppState.vaults = res.data
  }
}

export const ProfileService = new ProfileService()
