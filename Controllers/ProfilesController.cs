
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using DotnetContractors.Models;
using DotnetContractors.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetContractors.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly JobsService _js;

    public ProfilesController(ProfilesService ps, JobsService js)
    {
      _ps = ps;
      _js = js;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [HttpGet("{id}/jobs")]
    // public async Task<ActionResult<Profile>> GetJobsByProfile(string id)
    // {
    //   try
    //   {
    //     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    //     return Ok(_js.GetJobsByProfile(id, userInfo?.Id));
    //   }
    //   catch (System.Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }

    // }
  }
}