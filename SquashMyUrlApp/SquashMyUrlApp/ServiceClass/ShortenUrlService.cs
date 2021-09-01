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
        /// <returns></returns>
        public string GetShortenedUrl(string input)
        {
             //validate url
            if (_urlValidator.ValidateUrl(input))
            {
                //if valid check check cache first if it's in there return the stored value
                string cachedUrl = _squashModelRepository.GetShortenedUrl(input);

                if (string.IsNullOrWhiteSpace(cachedUrl))
                {
                    string shortUrlCode = _urlEncoder.EncodeUrl(input);
                    _squashModelRepository.AddShortenedUrl(input, shortUrlCode);
                    return shortUrlCode;
                }
                else
                {
                    return cachedUrl;
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
