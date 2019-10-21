using RestSharp.Deserializers;
using System.Collections.Generic;
using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class GetPaymentsResponse : BaseResponse
    { }

    public class GetBtcPaymentsResponse : GetPaymentsResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public List<CreateBtcPaymentPayload> Payments { get; protected set; } = new List<CreateBtcPaymentPayload>();
    }

    public class GetEthPaymentsResponse : GetPaymentsResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public List<CreateEthPaymentPayload> Payments { get; protected set; } = new List<CreateEthPaymentPayload>();
    }
}