using SquashMyUrl.DAL;
using SquashMyUrl.DAL.Interfaces;
using SquashMyUrlApp.Utilities;

namespace SquashMyUrlApp.ServiceClass
{
    /// <summary>
    /// service class to orchestrate Url operations in application
    /// </summary>
    public class ShortenUrlService : IShortenUrlService
    {
        private readonly UrlEncoder _urlEncoder;
        private readonly UrlValidator _urlValidator;
        private readonly ISquashModelRepository _squashModelRepository;

        //ShortenURlService should resovle it dependencies at run-time using IOC container like Auto-Frac
        public ShortenUrlService()
        {
            _urlEncoder = new UrlEncoder();
            _urlValidator = new UrlValidator();
            _squashModelRepository = new SquashModelRepository();
        }

        /// <summary>
        /// returns shortened url from cache
        /// if it doesn't exist will persist
        /// </summary>
        /// <param name="input"></param>
        /// <returns>url</returns>
        public string AddShortenedUrl(string input)
        {
            if (_urlValidator.ValidateUrl(input))
            {
                string shortUrlCode = _urlEncoder.EncodeUrl(input);
                _squashModelRepository.AddShortenedUrl(input, shortUrlCode);
                return shortUrlCode;
            }

            else
            {
                return string.Empty;
            }
        }

        public string TryGetCachedUrl(string input)
        {
            return _squashModelRepository.GetUrl(input).OriginalUrl;
        }
    }
}
