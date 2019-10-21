using RestSharp.Deserializers;
using System;
using CryptoApisLibrary.Exceptions;

namespace CryptoApisLibrary.DataTypes
{
    public class Trade : IEquatable<Trade>
    {
        /// <summary>
        /// Identifier of the exchange where symbol is traded.
        /// </summary>
        [DeserializeAs(Name = "exchangeId")]
        public string ExchangeId { get; protected set; }

        /// <summary>
        /// FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).
        /// </summary>
        [DeserializeAs(Name = "baseAsset")]
        public string BaseAsset { get; protected set; }

        /// <summary>
        /// FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).
        /// </summary>
        [DeserializeAs(Name = "quoteAsset")]
        public string QuoteAsset { get; protected set; }

        /// <summary>
        /// Type of symbol as string (possible values are: SPOT, FUTURES or OPTION).
        /// </summary>
        [DeserializeAs(Name = "tradeType")]
        public string TradeTypeAsString { get; protected set; }

        /// <summary>
        /// Aggressor side of the transaction as string (BUY/SELL/BUY_ESTIMATED/SELL_ESTIMATED/UNKNOWN).
        /// </summary>
        [DeserializeAs(Name = "direction")]
        public string TradeDirectionAsString { get; protected set; }

        /// <summary>
        /// Time of trade reported by exchange.
        /// </summary>
        [DeserializeAs(Name = "eventTime")]
        public DateTime EventTime { get; protected set; }

        /// <summary>
        /// Sequence number per pair (type, exchangeId) which is valid only for the lifespan of the connection.
        /// </summary>
        [DeserializeAs(Name = "exchangeSequenceId")]
        public string ExchangeSequenceId { get; protected set; }

        /// <summary>
        /// Price of the transaction.
        /// </summary>
        [DeserializeAs(Name = "price")]
        public double Price { get; protected set; }

        /// <summary>
        /// Base asset amount traded in the transaction.
        /// </summary>
        [DeserializeAs(Name = "amount")]
        public double Amount { get; protected set; }

        /// <summary>
        /// Type of symbol.
        /// </summary>
        public TradeType TradeType
        {
            get
            {
                if ("SPOT".Equals(TradeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Spot;
                if ("FUTURES".Equals(TradeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Futures;
                if ("OPTION".Equals(TradeTypeAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeType.Option;

                throw new UndefineTradeTypeException(TradeTypeAsString);
            }
        }

        /// <summary>
        /// Aggressor side of the transaction.
        /// </summary>
        public TradeDirection TradeDirection
        {
            get
            {
                if ("BUY".Equals(TradeDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeDirection.Buy;
                if ("SELL".Equals(TradeDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeDirection.Sell;
                if ("BUY_ESTIMATED".Equals(TradeDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeDirection.BuyEstimated;
                if ("SELL_ESTIMATED".Equals(TradeDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeDirection.SellEstimated;
                if ("UNKNOWN".Equals(TradeDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return TradeDirection.Unknown;

                throw new UndefineTradeDirectionException(TradeDirectionAsString);
            }
        }

        #region IEquatable<Trade>

        public bool Equals(Trade other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(ExchangeId, other.ExchangeId) && string.Equals(BaseAsset, other.BaseAsset) &&
                string.Equals(QuoteAsset, other.QuoteAsset) && string.Equals(TradeTypeAsString, other.TradeTypeAsString) &&
                string.Equals(TradeDirectionAsString, other.TradeDirectionAsString) && EventTime.Equals(other.EventTime) &&
                string.Equals(ExchangeSequenceId, other.ExchangeSequenceId) && Price.Equals(other.Price) && Amount.Equals(other.Amount);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is Trade && Equals((Trade)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ExchangeId != null ? ExchangeId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BaseAsset != null ? BaseAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (QuoteAsset != null ? QuoteAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TradeTypeAsString != null ? TradeTypeAsString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TradeDirectionAsString != null ? TradeDirectionAsString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ EventTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (ExchangeSequenceId != null ? ExchangeSequenceId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ Amount.GetHashCode();
                return hashCode;
            }
        }

        #endregion IEquatable<Trade>
    }
}