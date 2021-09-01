using SquashMyUrl.DAL.Utility;
using SquashMyUrlApp.Models;
using System.Collections.Generic;

namespace SquashMyUrl.DAL.DB
{
    /// <summary>
    /// This is just to simulate a DB insert but 
    /// will use the EF folder content to implement DB operations
    /// </summary>
    internal class SquashDB : ISquashDB
    {
        private static readonly List<UrlModel> _fakedb = new List<UrlModel>();

        /// <summary>
        /// commits url to DB
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <param name="encodedUrl"></param>
        /// <returns></returns>
        public bool TryAddShortenedUrl(UrlModel urlModel)
        {
            _fakedb.Add(urlModel);

            //assuming DB insert was successful
            return true;
        }

        /// <summary>
        /// retrieve short url from BD
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns></returns>
        public string GetShortenedUrl(string originalUrl)
        {
            UrlModel model = _fakedb.Find(m => m.OriginalUrl == originalUrl);
            if (!string.IsNullOrWhiteSpace(model?.ID))
            {
                return model.ID;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
