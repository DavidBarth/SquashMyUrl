using SquashMyUrl.DAL;
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
        private readonly SquashModelRepository _squashModelRepository;

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
            //check if exist in DB


            if (exists)
            {
                //if exist return

                return encodedUrl;
            }
            else
            {
                //else store in DB
                //return url
                return encodedUrl;
            }
        }
    }
}
