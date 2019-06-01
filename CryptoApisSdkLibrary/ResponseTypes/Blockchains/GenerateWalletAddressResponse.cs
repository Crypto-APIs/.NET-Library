﻿using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GenerateWalletAddressResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public GenerateWalletAddressPayload Payload { get; protected set; }
    }

    public class GenerateWalletAddressPayload
    {
        [DeserializeAs(Name = "wallet_info")]
        public WalletInfoPayload Wallet { get; protected set; }

        [DeserializeAs(Name = "address_info")]
        public AddressInfo Address { get; protected set; }
    }

    public class AddressInfo
    {
        [DeserializeAs(Name = "privateKey")]
        public string PrivateKey { get; protected set; }

        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }

        [DeserializeAs(Name = "publicKey")]
        public string PublicKey { get; protected set; }

        [DeserializeAs(Name = "wif")]
        public string Wif { get; protected set; }

        /// <remarks>
        /// Applied only for BCH
        /// </remarks>
        [DeserializeAs(Name = "bch")]
        public string Bch { get; protected set; }
    }
}