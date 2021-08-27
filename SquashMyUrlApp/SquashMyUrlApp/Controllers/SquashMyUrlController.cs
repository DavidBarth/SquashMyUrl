using Microsoft.AspNetCore.Mvc;
using SquashMyUrlApp.ServiceClass;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SquashMyUrlApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquashMyUrlController : ControllerBase
    {
        IShortenUrlService urlShortenerService;
        public SquashMyUrlController()
        {
            urlShortenerService = new ShortenUrlService();
        }
        
        // GET: api/<SquashMyUrlController>
        [HttpGet]
        public string GetShortenedUrl(string input)
        {
            return urlShortenerService.GetShortenedUrl(input);
        }
    }
}
