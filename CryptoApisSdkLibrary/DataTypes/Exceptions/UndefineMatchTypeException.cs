using System;

namespace CryptoApisSdkLibrary.DataTypes.Exceptions
{
    public sealed class UndefineMatchTypeException : InvalidOperationException
    {
        public UndefineMatchTypeException(string matchTypeAsString)
            : base($"\"{matchTypeAsString}\" is undefined match type")
        {
        }
    }
}