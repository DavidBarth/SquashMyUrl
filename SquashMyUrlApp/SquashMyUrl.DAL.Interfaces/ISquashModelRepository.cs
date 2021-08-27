namespace SquashMyUrl.DAL.Interfaces
{
    public interface ISquashModelRepository
    {
        string GetShortenedUrl(string encodedUrl);
        void AddShortenedUrl(string original, string encodedUrl);
    }
}
