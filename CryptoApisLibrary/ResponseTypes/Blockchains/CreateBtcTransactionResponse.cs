﻿using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class CreateBtcTransactionResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload
        {
            [DeserializeAs(Name = "hex")]
            public string Hex { get; protected set; }
        }
    }
}