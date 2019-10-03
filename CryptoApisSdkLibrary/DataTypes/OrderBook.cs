using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class OrderBook
    {
        /// <summary>
        /// Time of snapshot generation reported by exchange.
        /// </summary>
        [DeserializeAs(Name = "timestamp")]
        public long Timestamp { get; protected set; }

        /// <summary>
        /// Our identifier (UID) of the exchange where symbol is traded.
        /// </summary>
        [DeserializeAs(Name = "exchange_id")]
        public string ExchangeId { get; protected set; }

        /// <summary>
        /// Our identifier (UID) of the base asset.
        /// </summary>
        [DeserializeAs(Name = "base_asset")]
        public string BaseAsset { get; protected set; }

        /// <summary>
        /// Our identifier (UID) of the quote asset.
        /// </summary>
        [DeserializeAs(Name = "quote_asset")]
        public string QuoteAsset { get; protected set; }

        /// <summary>
        /// Exchange symbol identifier.
        /// </summary>
        [DeserializeAs(Name = "symbol")]
        public string Symbol { get; protected set; }

        /// <summary>
        /// Our symbol identifier, see table below for format description.
        /// </summary>
        [DeserializeAs(Name = "symbol_id")]
        public string SymbolId { get; protected set; }

        /// <summary>
        /// Depth of exchange for Book Snapshot level of 50.
        /// </summary>
        [DeserializeAs(Name = "depth")]
        public Depth Depth { get; protected set; }
    }

    public class Depth
    {
        /// <summary>
        /// Latest 50 bid levels in order from best to worst.
        /// </summary>
        [DeserializeAs(Name = "bids")]
        public List<Price> Bids { get; protected set; } = new List<Price>();

        /// <summary>
        /// Latest 50 ask levels in order from best to worst.
        /// </summary>
        [DeserializeAs(Name = "asks")]
        public List<Price> Asks { get; protected set; } = new List<Price>();
    }

    public class Price
    {
        /// <summary>
        /// Price of the bid/ask.
        /// </summary>
        [DeserializeAs(Name = "price")]
        public double Value { get; protected set; }

        /// <summary>
        /// Available amount of base to quote asset at the given price.
        /// </summary>
        [DeserializeAs(Name = "amount")]
        public double Amount { get; protected set; }
    }
}