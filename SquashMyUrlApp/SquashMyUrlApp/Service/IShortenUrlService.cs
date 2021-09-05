namespace SquashMyUrlApp.ServiceClass
{
    public interface IShortenUrlService
    {
        string AddShortenedUrl(string url);
        string TryGetCachedUrl(string input);
    }
}