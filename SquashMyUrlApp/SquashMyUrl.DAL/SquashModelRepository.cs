using SquashMyUrl.Interfaces;
using SquashMyUrlApp.Models;
using System.Collections.Generic;

namespace SquashMyUrl.DAL
{
    public class SquashModelRepository : IRepository<UrlModel>
    {
        public IEnumerable<UrlModel> List => throw new System.NotImplementedException();

        public void Add(UrlModel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(UrlModel entity)
        {
            throw new System.NotImplementedException();
        }

        public UrlModel FindById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(UrlModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
