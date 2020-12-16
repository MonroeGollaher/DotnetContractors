using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using DotnetContractors.Models;
using DotnetContractors.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetContractors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _cs;

        public ContractorsController(ContractorsService cs)
        {
            _cs = cs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Contractor>> Create([FromBody] Contractor newContractor)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newContractor.ContractorId = userInfo.Id;
                Contractor created = _cs.Create(newContractor);
                created.Creator = userInfo;
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}