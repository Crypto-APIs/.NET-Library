using CryptoApisSdkLibrary.DataTypes.Exceptions;
using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class QuoteTrade : IEquatable<QuoteTrade>
    {
        /// <summary>
        /// Symbol identifier custom for the exchange where trade took place.
        /// </summary>
        [DeserializeAs(Name = "exchangeSymbol")]
        public string ExchangeSymbol { get; protected set; }

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
        /// Initiator side of the transaction (ASKS/BIDS).
        /// </summary>
        [DeserializeAs(Name = "direction")]
        public string TradeDirectionAsString { get; protected set; }

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
        /// Time of trade reported by exchange.
        /// </summary>
        [DeserializeAs(Name = "eventTime")]
        public DateTime EventTime { get; protected set; }

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
        public QuoteTradeDirection TradeDirection
        {
            get
            {
                if ("ASKS".Equals(TradeDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return QuoteTradeDirection.Asks;
                if ("BIDS".Equals(TradeDirectionAsString, StringComparison.OrdinalIgnoreCase))
                    return QuoteTradeDirection.Bids;

                throw new UndefineQuoteTradeDirectionException(TradeDirectionAsString);
            }
        }

        #region IEquatable<QuoteTrade>

        public bool Equals(QuoteTrade other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(ExchangeSymbol, other.ExchangeSymbol) && string.Equals(ExchangeId, other.ExchangeId) &&
                string.Equals(BaseAsset, other.BaseAsset) && string.Equals(QuoteAsset, other.QuoteAsset) &&
                string.Equals(TradeTypeAsString, other.TradeTypeAsString) &&
                string.Equals(TradeDirectionAsString, other.TradeDirectionAsString) && Price.Equals(other.Price) &&
                Amount.Equals(other.Amount) && EventTime.Equals(other.EventTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((QuoteTrade)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ExchangeSymbol != null ? ExchangeSymbol.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ExchangeId != null ? ExchangeId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BaseAsset != null ? BaseAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (QuoteAsset != null ? QuoteAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TradeTypeAsString != null ? TradeTypeAsString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TradeDirectionAsString != null ? TradeDirectionAsString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ Amount.GetHashCode();
                hashCode = (hashCode * 397) ^ EventTime.GetHashCode();
                return hashCode;
            }
        }

        #endregion IEquatable<QuoteTrade>
    }
}