using System;
using System.ComponentModel.DataAnnotations;

namespace SquashMyUrl.Interfaces
{
    public class IEntity
    {
        [Key]
        public string Id;
    }
}
