using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Errors
{
    public class ErrorResponseVariant2
    {
        [DeserializeAs(Name = "meta")]
        public MetaError Meta { get; protected set; }

        public class MetaError
        {
            [DeserializeAs(Name = "error")]
            public ErrorInfo Error { get; protected set; }

            public class ErrorInfo
            {
                [DeserializeAs(Name = "code")]
                public int Code { get; protected set; }

                [DeserializeAs(Name = "Message")]
                public string Message { get; protected set; }
            }
        }
    }
}