using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using DotnetContractors.Models;
using DotnetContractors.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetContractors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorJobsController : ControllerBase
    {
        private readonly ContractorJobsService _cjs;

        public ContractorJobsController(ContractorJobsService cjs)
        {
            _cjs = cjs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ContractorJobs>> Post([FromBody] ContractorJobs newCj)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newCj.CreatorId = userInfo.Id;
                return Ok(_cjs.Create(newCj));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}