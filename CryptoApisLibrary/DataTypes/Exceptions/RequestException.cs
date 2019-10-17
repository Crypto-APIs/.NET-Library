using System;

namespace CryptoApisLibrary.DataTypes.Exceptions
{
    public class RequestException : ApplicationException
    {
        public RequestException(string errorMessage) : base(errorMessage)
        { }
    }
}