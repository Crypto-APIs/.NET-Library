using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Errors
{
    public class ErrorResponseVariant3
    {
        [DeserializeAs(Name = "timestamp")]
        public string Timestamp { get; protected set; }

        [DeserializeAs(Name = "status")]
        public int Status { get; protected set; }

        [DeserializeAs(Name = "error")]
        public string Error { get; protected set; }

        [DeserializeAs(Name = "Message")]
        public string Message { get; protected set; }

        [DeserializeAs(Name = "path")]
        public string Path { get; protected set; }
    }
}