using SquashMyUrlApp.Models;
using System;

namespace SquashMyUrl.DAL.Utility
{
    /// <summary>
    /// Utility class to build model for persistence 
    /// </summary>
    public class ModelBuilder
    {
        public static UrlModel BuildModel(string originalUrl, string encodedUrl)
        {
            UrlModel urlModel = new UrlModel
            {
                ShortenedUrl = encodedUrl,
                OriginalUrl = originalUrl,
                CreatedDate = DateTime.UtcNow
            };
            return urlModel;
        }
    }
}
