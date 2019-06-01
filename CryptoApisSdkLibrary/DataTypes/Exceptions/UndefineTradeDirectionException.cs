using System;

namespace CryptoApisSdkLibrary.DataTypes.Exceptions
{
    public sealed class UndefineTradeDirectionException : InvalidOperationException
    {
        public UndefineTradeDirectionException(string tradeDirectionAsString) 
            : base($"\"{tradeDirectionAsString}\" is undefined trade direction")
        {
        }
    }
}