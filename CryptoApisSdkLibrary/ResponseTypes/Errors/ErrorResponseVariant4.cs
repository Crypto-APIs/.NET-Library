using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Errors
{
    public class ErrorResponseVariant4
    {
        [DeserializeAs(Name = "meta")]
        public MetaError4 Meta { get; protected set; }
    }

    public class MetaError4
    {
        [DeserializeAs(Name = "errors")]
        public List<ErrorInfo4> Errors { get; protected set; } = new List<ErrorInfo4>();
    }

    public class ErrorInfo4
    {
        [DeserializeAs(Name = "error")]
        public string Message { get; protected set; }
    }
}