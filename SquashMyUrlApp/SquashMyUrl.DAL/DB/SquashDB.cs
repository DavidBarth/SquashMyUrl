using SquashMyUrlApp.Models;
using System;
using System.Collections.Generic;

namespace SquashMyUrl.DAL.DB
{
    /// <summary>
    /// This is just to simulate a DB insert but 
    /// will use the EF folder content to implement DB operations
    /// </summary>
    internal class SquashDB : ISquashDB
    {
        private static readonly Dictionary<string, UrlModel> _fakedb = new Dictionary<string, UrlModel>();

        public bool TryAddShortenedUrl(string originalUrl, string encodedUrl)
        {
            UrlModel urlModel = new UrlModel
            {
                ShortenedUrl = encodedUrl,
                CreatedDate = DateTime.UtcNow
            };
            _fakedb.Add(originalUrl, urlModel);

            //assuming DB insert was successful
            return true;
        }

        public string GetShortenedUrl(string originalUrl)
        {
            UrlModel model;
            _fakedb.TryGetValue(originalUrl, out  model);
            if (!string.IsNullOrWhiteSpace(model?.ShortenedUrl))
            {
                return model.ShortenedUrl;
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
