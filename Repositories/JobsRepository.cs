using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using DotnetContractors.Models;

namespace DotnetContractors.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;
    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (title, location, budget)
      VALUES
      (@Title, @Location, @Budget);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newJob);
    }
  }
}