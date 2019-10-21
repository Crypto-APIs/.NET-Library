using System;

namespace CryptoApisLibrary.Exceptions
{
    public sealed class UndefineTradeDirectionException : InvalidOperationException
    {
        public UndefineTradeDirectionException(string tradeDirectionAsString)
            : base($"\"{tradeDirectionAsString}\" is undefined trade direction")
        {
        }
    }
}