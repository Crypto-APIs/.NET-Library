using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class HdWalletInfoResponse : BaseResponse
    { }

    public class BtcHdWalletInfoResponse : HdWalletInfoResponse
    {
        [DeserializeAs(Name = "payload")]
        public BtcHdWalletInfoPayload Wallet { get; protected set; }

        public class BtcHdWalletInfoPayload
        {
            [DeserializeAs(Name = "addresses")]
            public List<BtcHdWalletAddress> Addresses { get; protected set; } = new List<BtcHdWalletAddress>();

            [DeserializeAs(Name = "walletName")]
            public string Name { get; protected set; }

            public class BtcHdWalletAddress
            {
                [DeserializeAs(Name = "path")]
                public string Path { get; protected set; }

                [DeserializeAs(Name = "address")]
                public string Address { get; protected set; }
            }
        }
    }

    public class BchHdWalletInfoResponse : HdWalletInfoResponse
    {
        [DeserializeAs(Name = "payload")]
        public BchHdWalletInfoPayload Wallet { get; protected set; }

        public class BchHdWalletInfoPayload
        {
            [DeserializeAs(Name = "addresses")]
            public List<BchHdWalletAddress> Addresses { get; protected set; } = new List<BchHdWalletAddress>();

            [DeserializeAs(Name = "walletName")]
            public string Name { get; protected set; }

            public class BchHdWalletAddress : BtcHdWalletInfoResponse.BtcHdWalletInfoPayload.BtcHdWalletAddress
            {
                [DeserializeAs(Name = "legacy")]
                public string Legacy { get; protected set; }
            }
        }
    }
}