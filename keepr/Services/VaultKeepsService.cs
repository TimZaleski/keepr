using System;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public VaultKeep Get(int id)
    {
      VaultKeep original = _repo.Get(id);
      if (original == null) { throw new Exception("Invalid Id"); }
      return original;
    }

    public VaultKeep Create(VaultKeep newVk)
    {
      int id = _repo.Create(newVk);
      newVk.Id = id;
      return newVk;
    }

    internal string Delete(int id, string userId)
    {
      VaultKeep original = _repo.Get(id);
      if (original == null) { throw new Exception("Bad ID"); }
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Vault that you did not create"); }
      _repo.Delete(id);
      return "successfully deleted";
    }
  }
}