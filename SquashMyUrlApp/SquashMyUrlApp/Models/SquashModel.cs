using SquashMyUrl.Interfaces;
using System;

namespace SquashMyUrlApp.Models
{
    /// <summary>
    /// model class used to map to DB
    /// </summary>
    public class SquashModel : IEntity
    {
        public int Id { get; set; }
        public string ShortenedUrl { get; set; }
        public string OriginalUrl { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
