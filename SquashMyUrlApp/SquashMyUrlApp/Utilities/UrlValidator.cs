using System;

namespace SquashMyUrlApp.Utilities
{
    /// <summary>
    /// class that contains validation of URLs
    /// for the SquasMyURL Service
    /// </summary>
    public class UrlValidator
    {
        private const int _MAX_INPUT_LENGTH = 2000; //assuming web browser don't handle longer URLs - from web source
        private string _urlInput;
        private int _inputLength => _urlInput.Length;

        //constructor
        public UrlValidator(string urlInput = null)
        {
            _urlInput = urlInput;
        }

        /// <summary>
        /// Validates input string length as first bastion
        /// </summa
        /// <returns>boolean</returns>
        public bool ValidateInputStringLength()
        {
            if (_urlInput == null || _inputLength < 1 || _inputLength > _MAX_INPUT_LENGTH)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates input URI. Checks for basic structure.
        /// </summary>
        /// <returns>boolean</returns>
        public bool ValidateInputURI()
        {
            try
            {
                Uri uri = new Uri(_urlInput);
                var dnsSafeHost = uri.DnsSafeHost;
                var absolutePath = uri.AbsolutePath;
            }
            catch (UriFormatException e)
            {
                throw e;
            }
            return true;
        }

        public bool ValidateUrl()
        {
            return ValidateInputStringLength() && ValidateInputURI();
        }
    }
}
