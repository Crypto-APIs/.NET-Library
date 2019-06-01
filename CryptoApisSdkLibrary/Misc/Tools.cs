using System;
using System.Globalization;

namespace CryptoApisSdkLibrary.Misc
{
    internal static class Tools
    {
        public static string ToUnixTimestamp(DateTime dateTime)
        {
            var unixTimestamp = (int)dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return unixTimestamp.ToString(CultureInfo.InvariantCulture);
        }
    }
}