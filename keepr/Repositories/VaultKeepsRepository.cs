using System;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Get(int id)
    {
      string sql = "SELECT * FROM vaultkeep WHERE id = @id;";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }

    public int Create(VaultKeep newVk)
    {
      string sql = @"
        INSERT INTO vaultkeep
        (creatorId, vaultId, keepId)
        VALUES
        (@CreatorId, @VaultId, @KeepId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVk);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeep WHERE id = @id;";
      _db.Execute(sql, new { id });
    }
    internal void RemoveVault(int id)
    {
      string sql = "DELETE FROM vaultkeep WHERE vaultId = @id;";
      _db.Execute(sql, new { id });
    }
  }
}