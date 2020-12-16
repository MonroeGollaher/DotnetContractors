using System;
using System.Data;
using Dapper;
using DotnetContractors.Models;

namespace DotnetContractors.Repositories
{
  public class ContractorsRespository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT contractor.*, profile.* FROM contractors contractor INNER JOIN profiles profile ON contractor.creatorId = profile.id ";

    public ContractorsRespository(IDbConnection db)
    {
        _db = db;
    }

    public int Create(Contractor newContractor)
    {
      string sql =@"
        INSERT INTO contractors
        (name, wage, contractorId)
        VALUES
        (@Name, @Wage, @ContractorId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newContractor);
    }
  }
}