﻿using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class DeleteWalletResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public DeleteWalletPayload Payload { get; protected set; }
    }

    public class DeleteWalletPayload
    {
        [DeserializeAs(Name = "message")]
        public string Message { get; protected set; }
    }
}