import { api } from './AxiosService'

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
