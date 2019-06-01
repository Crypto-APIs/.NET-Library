using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class HdWalletInfoResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public HdWalletInfoPayload Wallet { get; protected set; }
    }

    public class HdWalletInfoPayload
    {
        [DeserializeAs(Name = "addresses")]
        public List<HdWalletAddress> Addresses { get; protected set; } = new List<HdWalletAddress>();

        [DeserializeAs(Name = "walletName")]
        public string Name { get; protected set; }

        [DeserializeAs(Name = "hd")]
        public bool IsHierarchicalDeterministicWallet { get; protected set; }
    }

    public class HdWalletAddress
    {
        [DeserializeAs(Name = "path")]
        public string Path { get; protected set; }

        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }

        [DeserializeAs(Name = "legacy")]
        public string Legacy { get; protected set; }
    }
}