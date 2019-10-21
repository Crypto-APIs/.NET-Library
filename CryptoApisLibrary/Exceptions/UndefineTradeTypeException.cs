using System;

namespace CryptoApisLibrary.Exceptions
{
    public sealed class UndefineTradeTypeException : InvalidOperationException
    {
        public UndefineTradeTypeException(string tradeTypeAsString)
            : base($"\"{tradeTypeAsString}\" is undefined trade type")
        {
        }
    }
}