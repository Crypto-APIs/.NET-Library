using RestSharp.Deserializers;

namespace CryptoApisLibrary.DataTypes
{
    public class WebHook
    {
        [DeserializeAs(Name = "uuid")]
        public string Id { get; protected set; }

        [DeserializeAs(Name = "event")]
        public string Event { get; protected set; }

        [DeserializeAs(Name = "url")]
        public string Url { get; protected set; }
    }
}