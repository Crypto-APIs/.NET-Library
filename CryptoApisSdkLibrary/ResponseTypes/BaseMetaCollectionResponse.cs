using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes
{
    public abstract class BaseMetaCollectionResponse : BaseResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollection Meta { get; protected set; }
    }
}