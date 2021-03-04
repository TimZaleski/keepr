import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/api/account')
      AppState.account = res.data
      await this.getMyVaultsByAccountId(AppState.account.id)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getVaultsByAccountId(accountId) {
    const res = await api.get('/api/account/' + accountId + '/vaults')
    AppState.vaults = res.data
  }

  async getMyVaultsByAccountId(accountId) {
    const res = await api.get('/api/account/' + accountId + '/vaults')
    AppState.myVaults = res.data
  }
}

export const accountService = new AccountService()
