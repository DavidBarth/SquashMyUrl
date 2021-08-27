using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SquashMyUrlApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquashMyUrlController : ControllerBase
    {
        // GET: api/<SquashMyUrlController>
        [HttpGet]
        public string Get()
        {
            return null;
        }
    }
}
