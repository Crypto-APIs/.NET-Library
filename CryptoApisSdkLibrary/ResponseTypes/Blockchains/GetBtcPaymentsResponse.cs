using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public abstract class GetPaymentsResponse : BaseResponse
    { }

    public class GetBtcPaymentsResponse : GetPaymentsResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public List<CreateBtcPayment> Payments { get; protected set; } = new List<CreateBtcPayment>();
    }

    public class GetEthPaymentsResponse : GetPaymentsResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public List<CreateEthPayment> Payments { get; protected set; } = new List<CreateEthPayment>();
    }

}