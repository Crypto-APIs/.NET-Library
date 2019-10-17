using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes
{
    public abstract class BaseMetaCollectionResponse : BaseResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollection Meta { get; protected set; }
    }
}