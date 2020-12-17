using System;
using DotnetContractors.Models;
using DotnetContractors.Repositories;

namespace DotnetContractors.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;
    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }
    // internal object GetJobsByProfile(string id1, object id2)
    // {
    //   throw new NotImplementedException();
    // }
    public Job Create(Job newJob)
    {
      newJob.Id = _repo.Create(newJob);
      return newJob;
    }
  }
}