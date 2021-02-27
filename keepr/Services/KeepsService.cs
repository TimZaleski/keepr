using System;
using System.Collections.Generic;
using System.Linq;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> GetAll()
    {
      IEnumerable<Keep> keeps = _repo.GetAll();
      return keeps.ToList();
    }

    public Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }

    public Keep Get(int id)
    {
      Keep original = _repo.Get(id);
      if (original == null) { throw new Exception("Invalid Id"); }
      return original;
    }

    internal Keep Edit(Keep editData, string userId)
    {
      Keep original = Get(editData.Id);
      if (original.CreatorId != userId)
      {
        throw new Exception("Access Denied, You cannot edit something that is not yours");
      }
      editData.Views = editData.Views == null ? original.Views : editData.Views;
      editData.Shares = editData.Shares == null ? original.Shares : editData.Shares;
      editData.Shares = editData.Shares == null ? original.Shares : editData.Shares;
      return _repo.Edit(editData);
    }


    internal string Delete(int id, string userId)
    {
      Keep original = Get(id);
      if (original.CreatorId != userId)
      {
        throw new Exception("Access Denied, You cannot delete something that is not yours");
      }
      _repo.Remove(id);
      return "succesfully deleted";
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id).ToList();
    }

    internal IEnumerable<Keep> GetKeepsByAccountId(string id)
    {
      return _repo.GetByCreatorId(id);

    }
  }
}