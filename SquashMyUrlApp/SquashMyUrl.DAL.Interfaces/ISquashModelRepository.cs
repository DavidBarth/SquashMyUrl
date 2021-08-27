namespace SquashMyUrl.DAL.Interfaces
{
    public interface ISquashModelRepository
    {
        string CheckShortenedUrlExist(string encodedUrl);
    }
}
