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

    public VaultKeep Create(VaultKeep newVk)
    {
      int id = _repo.Create(newVk);
      newVk.Id = id;
      return newVk;
    }

    internal string Delete(int id)
    {
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}