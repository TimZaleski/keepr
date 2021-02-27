using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;
namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal Vault Get(int id)
    {
      string sql = @"
       SELECT 
       v.*,
       profile.* 
       FROM vault v 
       JOIN profiles profile ON v.creatorId = profile.id
       WHERE v.id = @id;";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Owner = profile; return vault; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal int Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO vault
      (creatorId, name, description, isPrivate)
      VALUES
      (@CreatorId, @Name, @Description, @IsPrivate);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vault WHERE id = @id;";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Vault> GetByCreatorId(string id)
    {
      string sql = @"
       SELECT 
       v.*,
       profile.* 
       FROM vault v 
       JOIN profiles profile ON v.creatorId = profile.id
       WHERE v.creatorId = @id;";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Owner = profile; return vault; }, new { id }, splitOn: "id");

    }
  }
}