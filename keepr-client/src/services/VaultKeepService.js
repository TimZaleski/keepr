import { AppState } from '../AppState'
import { api } from './AxiosService'
import { profileService } from '../services/ProfileService'
import { accountService } from '../services/AccountService'
import { useRouter } from 'vue-router'

const baseURL = '/api/vaultkeeps/'

class VaultKeepService {
  async createVaultKeep(vaultId, keepId) {
    const data = {
      VaultId: vaultId,
      KeepId: keepId
    }
    await api.post(baseURL, data)
  }
}

export const vaultKeepService = new VaultKeepService()
