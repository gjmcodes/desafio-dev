using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ByC.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        // GET: api/Cnab
        [HttpGet("health-check")]
        public IActionResult GetHealthCheck()
        {
            return Ok();
        }

        // GET: api/Cnab
        [HttpGet("environment-variable/{env}")]
        public IActionResult GetHealthCheck(string env)
        {
            return Ok(Environment.GetEnvironmentVariable(env));
        }
    }
}
