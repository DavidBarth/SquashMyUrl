using NUnit.Framework;
using SquashMyUrlApp.Utilities;
using System;

namespace SquashMyUrl.Test
{
    class UrlValidatorTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestUrlConverterHasNullInput()
        {
            UrlValidator uRLConverter = new UrlValidator(null);

            bool result = uRLConverter.ValidateInputStringLength();

            Assert.IsFalse(result);
        }

        [Test]
        public void TestUrlConverterHasStringLengthZero()
        {
            string testString = string.Empty;
            UrlValidator uRLConverter = new UrlValidator(testString);

            bool result = uRLConverter.ValidateInputStringLength();

            Assert.IsFalse(result);
        }

        [Test]
        public void TestUrlConverterInputExceededMaxURLLength()
        {
            string testString = UtilityClass.GetTestString(2001);
            UrlValidator uRLConverter = new UrlValidator(testString);

            bool result = uRLConverter.ValidateInputStringLength();

            Assert.IsFalse(result);
        }

        [Test]
        public void TestUrlConverterInputLengthIsValid()
        {
            string testString = UtilityClass.GetTestString(100);
            UrlValidator uRLConverter = new UrlValidator(testString);

            var result = uRLConverter.ValidateInputStringLength();

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("www.goog.com")]
        [TestCase("developer.mozilla.org/")]
        [TestCase("htt://www.google..c")]
        [TestCase("www.google.com")]
        public void TestThatURIValidatorThrowsException(string testParam)
        {
            UrlValidator uRLConverter = new UrlValidator(testParam);

            Assert.Throws<UriFormatException>(() => uRLConverter.ValidateInputURI());
        }

        [Test]
        [TestCase("https://en.wikipedia.org/wiki/URL_shortening")]
        public void TestThatURIValidatonPass(string testParam)
        {
            UrlValidator uRLConverter = new UrlValidator(testParam);

            Assert.True(uRLConverter.ValidateInputURI());
        }

        [Test]
        public void TestInputURIIsValid()
        {
            UrlValidator uRLConverter = new UrlValidator("https://docs.microsoft.com/en-us/dotnet/api/system.uri.-ctor?view=net-5.0");
            string result = uRLConverter.ExractPartOfURLToConvert();

            Assert.False(result.Length > 0);
        }
    }
}
