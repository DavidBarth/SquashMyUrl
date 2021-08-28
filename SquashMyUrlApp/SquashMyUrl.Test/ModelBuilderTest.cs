using NUnit.Framework;
using SquashMyUrl.DAL.Utility;
using SquashMyUrlApp.Models;
using SquashMyUrlApp.Utilities;

namespace SquashMyUrl.Test
{
    class ModelBuilderTest
    {
        private UrlEncoder _urlEncoder;

        [SetUp]
        public void Setup()
        {
            _urlEncoder = new UrlEncoder();
        }

        [Test]
        [TestCase("https://www.coingecko.com/en/coins/adax")]
        public void TestUrlEncoderReturnsShortenedUrl(string originalUrl)
        {
            string encodedUrl = _urlEncoder.EncodeUrl(originalUrl);
            UrlModel urlModel = ModelBuilder.BuildModel(originalUrl, encodedUrl);

            Assert.True(urlModel.ShortenedUrl.Equals(encodedUrl));
            Assert.True(urlModel.OriginalUrl.Equals(originalUrl));
        }
    }
}
