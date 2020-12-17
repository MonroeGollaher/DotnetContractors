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
    public class JobsController : ControllerBase
    {
        private readonly JobsService _js;

        public JobsController(JobsService js)
        {
            _js = js;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                Job creeated = _js.Create(newJob);
                return Ok(creeated);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}