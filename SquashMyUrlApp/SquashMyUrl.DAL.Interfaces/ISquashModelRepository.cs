namespace SquashMyUrl.DAL.Interfaces
{
    public interface ISquashModelRepository
    {
        string GetShortenedUrl(string encodedUrl);
    }
}
