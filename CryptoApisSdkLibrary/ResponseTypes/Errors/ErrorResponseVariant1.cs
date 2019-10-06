using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Errors
{
    public class ErrorResponseVariant1
    {
        [DeserializeAs(Name = "meta")]
        public ErrorMessage Meta { get; protected set; }

        public class ErrorMessage
        {
            [DeserializeAs(Name = "Message")]
            public string Message { get; protected set; }
        }
    }
}