using System;
using System.Collections.Generic;
using DotnetContractors.Models;
using DotnetContractors.Repositories;

namespace DotnetContractors.Services
{
  public class ContractorJobsService
  {
    private readonly ContractorJobsRepository _repo;
    public ContractorJobsService(ContractorJobsRepository repo)
    {
        _repo = repo;
    }
    public ContractorJobs Create(ContractorJobs newCj)
    {
      newCj.Id = _repo.Create(newCj);
      return newCj;
    }
  }
}