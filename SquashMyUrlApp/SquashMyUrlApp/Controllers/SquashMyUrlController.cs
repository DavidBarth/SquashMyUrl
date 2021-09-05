using Microsoft.AspNetCore.Mvc;
using SquashMyUrlApp.ServiceClass;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SquashMyUrlApp.Controllers
{
    /// <summary>
    /// public api, entry to service
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SquashMyUrlController : ControllerBase
    {
        IShortenUrlService urlShortenerService;
        public SquashMyUrlController()
        {
            urlShortenerService = new ShortenUrlService();
        }

        [HttpGet]
        public ActionResult GetShortenedUrl(string input)
        {
            string cachedUrl = urlShortenerService.TryGetCachedUrl(input);
            if (string.IsNullOrEmpty(cachedUrl))
            {
                string shortUrl = urlShortenerService.AddShortenedUrl(input);
                return Ok($"https://localhost:44347/api/squashmyurl?input={shortUrl}");
            }
            else
            {
                return Redirect(cachedUrl);
            }
        }
    }
}
