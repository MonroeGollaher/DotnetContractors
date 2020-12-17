using System;
using System.Data;
using Dapper;
using DotnetContractors.Models;

namespace DotnetContractors.Repositories
{
  public class ContractorJobsRepository
  {
    private readonly IDbConnection _db;

    public ContractorJobsRepository(IDbConnection db)
    {
        _db = db;
    }
    public int Create(ContractorJobs newCj)
    {
      string sql = @"
        INSERT INTO contractorjobs
        (jobId, contractorId, creatorId)
        VALUES
        (@JobId, @ContractorId, @CreatorId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newCj);
    }
  }
}