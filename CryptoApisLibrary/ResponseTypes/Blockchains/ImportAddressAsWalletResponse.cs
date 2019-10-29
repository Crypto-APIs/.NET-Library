using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class ImportAddressAsWalletResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload
        {
            [DeserializeAs(Name = "walletName")]
            public string WalletName { get; protected set; }

            [DeserializeAs(Name = "addresses")]
            public List<AddressPayload> Addresses { get; } = new List<AddressPayload>();

            public class AddressPayload
            {
                [DeserializeAs(Name = "address")]
                public string Address { get; protected set; }
            }
        }
    }
}