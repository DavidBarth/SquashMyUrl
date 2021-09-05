using System.Linq;
using System.Text;

namespace SquashMyUrlApp.Utilities
{
    /// <summary>
    /// encoding algorithm that uses convert from base 10 to base 62
    /// </summary>
    public class UrlEncoder
    {
        static long COUNTER = 100000000000;
        string safeUrlElements = "0123456789abcdefghIjklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// returns short code for
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string EncodeUrl(string input = null)
        {
            if(input != null)
            {
                string shortUrl = Base10ToBase62(COUNTER);
                COUNTER++;
                return shortUrl;
            }
            else
            {
                return string.Empty;
            }
        }

        private string Base10ToBase62(long counter)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while(counter != 0)
            {
                long remainder = counter % 62;
                int element = (int)remainder;
                stringBuilder.Append(safeUrlElements.ElementAt(element));
                counter /= 62;
            }

            return stringBuilder.ToString();
        }
    }
}
