using System;

namespace CryptoApisLibrary.Exceptions
{
    public sealed class UndefineMatchTypeException : InvalidOperationException
    {
        public UndefineMatchTypeException(string matchTypeAsString)
            : base($"\"{matchTypeAsString}\" is undefined match type")
        {
        }
    }
}