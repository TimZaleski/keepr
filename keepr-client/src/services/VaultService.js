import { AppState } from '../AppState'
import { api } from './AxiosService'
import { accountService } from '../services/AccountService'

const baseURL = '/api/vaults/'

class VaultService {
  async getVault(vaultId) {
    const res = await api.get(baseURL + vaultId)
    AppState.activeVault = res.data
  }

  async createVault(data) {
    await api.post(baseURL, data)
    accountService.getMyVaultsByAccountId()
    accountService.getVaultsByAccountId(AppState.account.id)
  }

  async deleteVault(id) {
    await api.delete(baseURL + id)
    AppState.activeVault = null
    AppState.vaults = null
  }
}

export const vaultService = new VaultService()
