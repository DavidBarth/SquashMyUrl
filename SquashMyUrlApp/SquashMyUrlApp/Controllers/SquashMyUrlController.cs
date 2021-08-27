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
        //usage https://<yourownlocalostandport>/api/squashmyurl?input=https://www.kerstner.at/2012/07/shortening-strings-using-base-62-encoding/
        //after encoding O9Oz9L1 
        // GET: api/<SquashMyUrlController>
        [HttpGet]
        public string GetShortenedUrl(string input)
        {
            return urlShortenerService.GetShortenedUrl(input);
        }
    }
}
