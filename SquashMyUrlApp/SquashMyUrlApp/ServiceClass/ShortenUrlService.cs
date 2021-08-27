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
        public string CalculateShortenedUrl()
        {
            throw new System.NotImplementedException();
        }

        public string GetShortenedUrl(string input)
        {
            string encodedUrl = string.Empty;

            //validate url
            if (_urlValidator.ValidateUrl(input))
            {
                //convert url
                encodedUrl = _urlEncoder.EncodeUrl(input);
            }
            else
            {
                return string.Empty;
            }

            bool exists = false;
            //check if exist in Cache
            string cachedUrl = _squashModelRepository.GetShortenedUrl(encodedUrl);

            if (!string.IsNullOrWhiteSpace(cachedUrl))
            {
                //if exist then it's in DB return

                return cachedUrl;
            }
            //might not need this as repository will do check and commit
            else
            {
                //else store in Cache and DB
                //return url
                return encodedUrl;
            }
        }
    }
}
