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
    private readonly VaultsRepository _vrepo;
    public KeepsService(KeepsRepository repo, VaultsRepository vrepo)
    {
      _repo = repo;
      _vrepo = vrepo;
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
      editData.Name = editData.Name == null ? original.Name : editData.Name;
      editData.Img = editData.Img == null ? original.Img : editData.Img;
      editData.Description = editData.Description == null ? original.Description : editData.Description;
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
      Vault data = _vrepo.Get(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      if (data.IsPrivate == true) { throw new Exception("Access Denied: Cannot access a private Vault that you did not create"); }
      return _repo.GetKeepsByVaultId(id);
    }

    internal IEnumerable<Keep> GetKeepsByAccountId(string id)
    {
      return _repo.GetByCreatorId(id);

    }
  }
}