﻿using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class NewBtcTransactionResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public NewBtcTransaction Payload { get; protected set; }
    }

    public class NewBtcTransaction
    {
        [DeserializeAs(Name = "txid")]
        public string Txid { get; protected set; }
    }
}