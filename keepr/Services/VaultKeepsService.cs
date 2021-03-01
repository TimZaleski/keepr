using System;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    private readonly KeepsRepository _krepo;

    public VaultKeepsService(VaultKeepsRepository repo, KeepsRepository krepo)
    {
      _repo = repo;
      _krepo = krepo;
    }

    public VaultKeep Get(int id)
    {
      VaultKeep original = _repo.Get(id);
      if (original == null) { throw new Exception("Invalid Id"); }
      return original;
    }

    public VaultKeep Create(VaultKeep newVk)
    {
      Keep k =  _krepo.Get(newVk.KeepId);
      if (k != null)
      {
        k.Keeps = k.Keeps + 1;
        _krepo.Edit(k);
      }
      int id = _repo.Create(newVk);
      newVk.Id = id;
      return newVk;
    }

    internal string Delete(int id, string userId)
    {
      VaultKeep original = _repo.Get(id);
      if (original == null) { throw new Exception("Bad ID"); }
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Vault that you did not create"); }
      Keep k =  _krepo.Get(original.KeepId);
      if (k != null)
      {
        k.Keeps = k.Keeps - 1;
        _krepo.Edit(k);
      }
      _repo.Delete(id);
      return "successfully deleted";
    }
  }
}