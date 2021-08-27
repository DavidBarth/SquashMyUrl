using NUnit.Framework;
using SquashMyUrlApp.Utilities;
using System;

namespace SquashMyUrl.Test
{
    class UrlValidatorTest
    {
        UrlValidator _urlValidator;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestUrlConverterHasNullInput()
        {
            _urlValidator = new UrlValidator(null);

            bool result = _urlValidator.ValidateInputStringLength();

            Assert.IsFalse(result);
        }

        [Test]
        public void TestUrlConverterHasStringLengthZero()
        {
            string testString = string.Empty;
            _urlValidator = new UrlValidator(testString);

            bool result = _urlValidator.ValidateInputStringLength();

            Assert.IsFalse(result);
        }

        [Test]
        public void TestUrlConverterInputExceededMaxURLLength()
        {
            string testString = UtilityClass.GetTestString(2001);
            _urlValidator = new UrlValidator(testString);

            bool result = _urlValidator.ValidateInputStringLength();

            Assert.IsFalse(result);
        }

        [Test]
        public void TestUrlConverterInputLengthIsValid()
        {
            string testString = UtilityClass.GetTestString(100);
            _urlValidator = new UrlValidator(testString);

            var result = _urlValidator.ValidateInputStringLength();

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("www.goog.com")]
        [TestCase("developer.mozilla.org/")]
        [TestCase("htt://www.google..c")]
        [TestCase("www.google.com")]
        public void TestThatURIValidatorThrowsException(string testParam)
        {
            _urlValidator = new UrlValidator(testParam);

            Assert.Throws<UriFormatException>(() => _urlValidator.ValidateInputURI());
        }

        [Test]
        [TestCase("https://en.wikipedia.org/wiki/URL_shortening")]
        public void TestThatURIValidatonPass(string testParam)
        {
            _urlValidator = new UrlValidator(testParam);

            Assert.True(_urlValidator.ValidateInputURI());
        }

        [Test]
        [TestCase("https://en.wikipedia.org/wiki/URL_shortening")]
        public void TestInputURIIsValid(string testParam)
        {
            _urlValidator = new UrlValidator(testParam);
            bool result = _urlValidator.ValidateUrl();

            Assert.True(result);
        }
    }
}
