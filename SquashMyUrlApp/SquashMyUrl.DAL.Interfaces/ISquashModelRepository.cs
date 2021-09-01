namespace SquashMyUrl.DAL.Interfaces
{
    public interface ISquashModelRepository
    {
        string GetShortenedUrl(string shortUrlCode);
        void AddShortenedUrl(string original, string shortUrlCode);
    }
}
