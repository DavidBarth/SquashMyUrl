using NUnit.Framework;
using SquashMyUrlApp.Utilities;

namespace SquashMyUrl.Test
{
    class UrlEncoderTest
    {
        UrlEncoder _urlEncoder;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("https://coinmarketcap.com/currencies/terra-luna/")]
        public void TestUrlEncoderReturnsShortenedUrl(string inputParam)
        {
            _urlEncoder = new UrlEncoder(inputParam);

            string encodedUrl = _urlEncoder.EncodeUrl();

            Assert.True(encodedUrl.Length > 0);
        }
    }
}
