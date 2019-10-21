using RestSharp.Deserializers;
using System;
using CryptoApisLibrary.Exceptions;

namespace CryptoApisLibrary.DataTypes
{
    public class ExchangeAssets : IEquatable<ExchangeAssets>
    {
        /// <summary>
        /// Unique symbol identification string (UID).
        /// </summary>
        [DeserializeAs(Name = "symbolId")]
        public string SymbolId { get; protected set; }

        /// <summary>
        /// Our identifier (UID) of the exchange where symbol is traded.
        /// </summary>
        [DeserializeAs(Name = "exchangeId")]
        public string ExchangeId { get; protected set; }

        /// <summary>
        /// Our symbol identifier, see table below for format description.
        /// </summary>
        [DeserializeAs(Name = "exchangeSymbol")]
        public string ExchangeSymbol { get; protected set; }

        /// <summary>
        /// FX Spot base asset identifier (UID), for derivatives it’s contact underlying (e.g. BTC for BTC/USD)
        /// </summary>
        [DeserializeAs(Name = "baseAsset")]
        public string BaseAsset { get; protected set; }

        /// <summary>
        /// FX Spot quote asset identifier (UID), for derivatives it’s contract underlying (e.g. USD for BTC/USD)
        /// </summary>
        [DeserializeAs(Name = "quoteAsset")]
        public string QuoteAsset { get; protected set; }

        /// <summary>
        /// Type of symbol (possible values are: SPOT, FUTURES or OPTION)
        /// </summary>
        [DeserializeAs(Name = "tradeType")]
        public string TradeTypeAsString { get; protected set; }

        /// <summary>
        /// Exchange type, where the initial quote took place.
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

        public override string ToString()
        {
            return ExchangeSymbol;
        }

        #region IEquatable<ExchangeAssets>

        public bool Equals(ExchangeAssets other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return SymbolId == other.SymbolId && ExchangeId == other.ExchangeId &&
                   ExchangeSymbol == other.ExchangeSymbol && BaseAsset == other.BaseAsset &&
                   QuoteAsset == other.QuoteAsset && TradeTypeAsString == other.TradeTypeAsString;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((ExchangeAssets)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (SymbolId != null ? SymbolId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ExchangeId != null ? ExchangeId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ExchangeSymbol != null ? ExchangeSymbol.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BaseAsset != null ? BaseAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (QuoteAsset != null ? QuoteAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TradeTypeAsString != null ? TradeTypeAsString.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<ExchangeAssets>
    }
}