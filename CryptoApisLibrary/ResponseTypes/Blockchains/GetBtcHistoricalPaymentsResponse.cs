using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class GetHistoricalPaymentsResponse : BaseResponse
    { }

    public class GetBtcHistoricalPaymentsResponse : GetHistoricalPaymentsResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public List<GetBtcHistoricalPayments> Payments { get; protected set; } = new List<GetBtcHistoricalPayments>();
    }

    public class GetEthHistoricalPaymentsResponse : GetHistoricalPaymentsResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public List<CreateEthHistoricalPayment> Payments { get; protected set; } = new List<CreateEthHistoricalPayment>();
    }

    public class GetBtcHistoricalPayments
    {
        [DeserializeAs(Name = "status")]
        public string Status { get; protected set; }

        [DeserializeAs(Name = "uuid")]
        public string Id { get; protected set; }

        [DeserializeAs(Name = "block_height")]
        public int BlockHeight { get; protected set; }

        [DeserializeAs(Name = "txid")]
        public string TransactionId { get; protected set; }

        [DeserializeAs(Name = "payment_uuid")]
        public string PaymentId { get; protected set; }
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