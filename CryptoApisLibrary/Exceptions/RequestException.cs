using System;

namespace CryptoApisLibrary.Exceptions
{
    public class RequestException : ApplicationException
    {
        public RequestException(string errorMessage) : base(errorMessage)
        { }
    }
}