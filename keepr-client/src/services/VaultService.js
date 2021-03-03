import { AppState } from '../AppState'
import { api } from './AxiosService'
import { profileService } from '../services/ProfileService'
import { accountService } from '../services/AccountService'
import { useRouter } from 'vue-router'

const baseURL = '/api/vaults/'

class VaultService {
  async getVault(vaultId) {
    const res = await api.get(baseURL + vaultId)
    AppState.activeVault = res.data
  }

  async createVault(data) {
    await api.post(baseURL, data)
    accountService.getMyVaultsByAccountId()
    profileService.getVaultsByProfileId(AppState.account.id)
  }

  async deleteVault(id) {
    const router = useRouter()
    await api.delete(baseURL + id)
    AppState.activeVault = null
    AppState.vaults = null
    router.push('/profiles/' + AppState.account.id)
  }
}

export const vaultService = new VaultService()
