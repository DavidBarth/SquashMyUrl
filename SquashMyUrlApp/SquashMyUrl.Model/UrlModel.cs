using System;

namespace SquashMyUrlApp.Models
{
    /// <summary>
    /// model class used to map to DB
    /// will represent a record in table
    /// </summary>
    public class UrlModel
    {
        public string ID { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
