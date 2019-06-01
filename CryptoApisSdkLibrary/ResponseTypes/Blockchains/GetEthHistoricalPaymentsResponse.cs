using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GetEthHistoricalPaymentsResponse : BaseResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public List<CreateEthHistoricalPayment> Payments { get; protected set; } = new List<CreateEthHistoricalPayment>();
    }

    public class CreateEthHistoricalPayment
    {
        [DeserializeAs(Name = "payment_uuid")]
        public string PaymentId { get; protected set; }

        [DeserializeAs(Name = "status")]
        public string Status { get; protected set; }

        [DeserializeAs(Name = "block_height")]
        public int BlockHeight { get; protected set; }

        [DeserializeAs(Name = "transaction")]
        public string Transaction { get; protected set; }

        [DeserializeAs(Name = "uuid")]
        public string Id { get; protected set; }
    }

}