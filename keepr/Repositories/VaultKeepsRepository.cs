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

    public int Create(VaultKeep newVk)
    {
      string sql = @"
        INSERT INTO vaultkeep
        (vaultId, keepId)
        VALUES
        (@VaultId, @KeepId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVk);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeep WHERE id = @id;";
      _db.Execute(sql, new { id });
    }
  }
}