namespace SquashMyUrlApp.ServiceClass
{
    public interface IShortenUrlService
    {
        string GetShortenedUrl(string url);
        string CalculateShortenedUrl();
    }
}