using SquashMyUrl.Interfaces;
using SquashMyUrlApp.Models;
using System.Collections.Generic;

namespace SquashMyUrl.DAL
{
    public class SquashModelRepository : IRepository<SquashModel>
    {
        public IEnumerable<SquashModel> List => throw new System.NotImplementedException();

        public void Add(SquashModel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(SquashModel entity)
        {
            throw new System.NotImplementedException();
        }

        public SquashModel FindById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(SquashModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
