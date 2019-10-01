using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public abstract class GetInfoResponse : BaseResponse
    { }

    public class GetBtcInfoResponse : GetInfoResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetBtcInfoPayload Info { get; protected set; }
    }

    public class GetEthInfoResponse : GetInfoResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetEthInfoPayload Info { get; protected set; }
    }

    public abstract class BaseGetInfoPayload
    {
        [DeserializeAs(Name = "difficulty")]
        public double Difficulty { get; protected set; }

        [DeserializeAs(Name = "chain")]
        public string Chain { get; protected set; }

        [DeserializeAs(Name = "bestBlockHash")]
        public string BestBlockHash { get; protected set; }
    }

    public class GetBtcInfoPayload : BaseGetInfoPayload
    {
        [DeserializeAs(Name = "headers")]
        public int Headers { get; protected set; }

        [DeserializeAs(Name = "chainWork")]
        public string ChainWork { get; protected set; }

        [DeserializeAs(Name = "mediantime")]
        public DateTime Mediantime { get; protected set; }

        [DeserializeAs(Name = "blocks")]
        public int Blocks { get; protected set; }

        [DeserializeAs(Name = "currency")]
        public string Currency { get; protected set; }

        [DeserializeAs(Name = "transactions")]
        public int Transactions { get; protected set; }

        [DeserializeAs(Name = "verificationProgress")]
        public double VerificationProgress { get; protected set; }
    }

    public class GetEthInfoPayload : BaseGetInfoPayload
    {
        [DeserializeAs(Name = "height")]
        public int Height { get; protected set; }

        [DeserializeAs(Name = "txs_count")]
        public int TxsCount { get; protected set; }

        [DeserializeAs(Name = "synced")]
        public bool Synced { get; protected set; }
    }
}