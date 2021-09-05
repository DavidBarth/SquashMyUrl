using SquashMyUrlApp.Models;

namespace SquashMyUrl.DAL
{
    //this cache is specific to DAL so leaving in .DAL
    public interface ISquashModelCache
    {
        UrlModel Get(string originalUrl);
        void Add(UrlModel model);
    }
}