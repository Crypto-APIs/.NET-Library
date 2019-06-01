using System;

namespace CryptoApisSdkLibrary.DataTypes.Exceptions
{
    public class RequestException : Exception
    {
        public RequestException(string errorMessage) : base(errorMessage)
        { }
    }
}