using System;
using System.Collections.Generic;
using DotnetContractors.Models;
using DotnetContractors.Repositories;

namespace DotnetContractors.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRespository _repo;

    public ContractorsService(ContractorsRespository repo)
    {
      _repo = repo;
    }
    public Contractor Create(Contractor newContractor)
    {
      newContractor.Id = _repo.Create(newContractor);
      return newContractor;
    }

    public IEnumerable<Contractor> Get()
    {
      return _repo.Get();
    }
  }
}