using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GetBtcHistoricalPaymentsResponse : BaseResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public List<GetBtcHistoricalPayments> Payments { get; protected set; } = new List<GetBtcHistoricalPayments>();
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
}