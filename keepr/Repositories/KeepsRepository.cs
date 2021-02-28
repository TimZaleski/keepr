using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {

    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
       SELECT 
       k.*,
       profile.* 
       FROM keep k 
       JOIN profiles profile ON k.creatorId = profile.id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, splitOn: "id");
    }

    internal Keep Get(int id)
    {
      string sql = @"
       SELECT 
       k.*,
       profile.* 
       FROM keep k 
       JOIN profiles profile ON k.creatorId = profile.id
       WHERE k.id = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keep
      (creatorId, name, description, img)
      VALUES
      (@CreatorId, @Name, @Description, @Img);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    internal Keep Edit(Keep editData)
    {
      string sql = @"
     UPDATE keep
     SET
     name = @Name,
     img = @Img,
     description = @Description,
     views = @Views,
     shares = @Shares,
     keeps = @Keeps
     WHERE id = @Id;";
      _db.Execute(sql, editData);
      return editData;
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM keep WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {
      string sql = @"
      SELECT k.*,
      vk.id as VaultKeepId 
      FROM vaultkeep vk
      JOIN keep k ON k.id = vk.keepId
      WHERE vaultId = @vaultId";

      return _db.Query<VaultKeepViewModel>(sql, new { vaultId });
    }

    internal IEnumerable<Keep> GetByCreatorId(string id)
    {
      string sql = @"
       SELECT 
       k.*,
       profile.* 
       FROM keep k 
       JOIN profiles profile ON k.creatorId = profile.id
       WHERE k.creatorId = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { id }, splitOn: "id");

    }
  }
}