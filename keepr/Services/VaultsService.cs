using System;
using System.Collections.Generic;
using System.Linq;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal Vault Get(int id)
    {
      var data = _repo.Get(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }


    public Vault Create(Vault newVault)
    {
      newVault.Id = _repo.Create(newVault);
      return newVault;
    }

    internal string Delete(int id, string userId)
    {
      Vault original = _repo.Get(id);
      if (original == null) { throw new Exception("Bad ID"); }
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Vault that you did not create"); }
      _repo.Delete(id);
      return "successfully deleted";
    }

    internal IEnumerable<Vault> GetVaultsByAccountId(string id)
    {
      return _repo.GetByCreatorId(id);
    }

    internal IEnumerable<Vault> GetByProfileId(string id)
    {
      return _repo.GetByCreatorId(id).ToList().FindAll(r => !r.IsPrivate);
    }
  }
}