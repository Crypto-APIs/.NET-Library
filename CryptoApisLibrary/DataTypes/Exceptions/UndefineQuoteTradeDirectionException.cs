using System;

namespace CryptoApisLibrary.DataTypes.Exceptions
{
    public sealed class UndefineQuoteTradeDirectionException : InvalidOperationException
    {
        public UndefineQuoteTradeDirectionException(string tradeDirectionAsString)
            : base($"\"{tradeDirectionAsString}\" is undefined trade direction")
        {
        }
    }
}