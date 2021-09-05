using SquashMyUrlApp.Models;

namespace SquashMyUrl.DAL.Interfaces
{
    public interface ISquashModelRepository
    {
        UrlModel GetUrl(string shortUrlCode);
        void AddShortenedUrl(string original, string shortUrlCode);
    }
}
