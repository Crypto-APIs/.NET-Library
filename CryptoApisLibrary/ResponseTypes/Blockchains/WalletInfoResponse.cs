using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class WalletInfoResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public WalletInfoPayload Wallet { get; protected set; }
    }

    public class WalletInfoPayload
    {
        [DeserializeAs(Name = "addresses")]
        public List<string> Addresses { get; protected set; } = new List<string>();

        /// <remarks>
        /// Applied only for BCH
        /// </remarks>
        [DeserializeAs(Name = "legacy")]
        public List<string> Legacy { get; protected set; }

        [DeserializeAs(Name = "walletName")]
        public string Name { get; protected set; }

        [DeserializeAs(Name = "hd")]
        public bool IsHierarchicalDeterministicWallet { get; protected set; }
    }
}