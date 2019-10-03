using System;

namespace CryptoApisSdkLibrary.DataTypes.Exceptions
{
    public class RequestException : ApplicationException
    {
        public RequestException(string errorMessage) : base(errorMessage)
        { }
    }
}