using CryptoApisSdkLibrary.DataTypes.Exceptions;
using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class Symbol : IEquatable<Symbol>
    {
        /// <summary>
        /// Default constructor need for serialization/deserialization.
        /// </summary>
        public Symbol()
        {
        }

        public Symbol(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Symbol identifier.
        /// </summary>
        [DeserializeAs(Name = "exchangeSymbol")]
        public string Name { get; protected set; }

        /// <summary>
        /// Identifier of the exchange where symbol is traded.
        /// </summary>
        [DeserializeAs(Name = "exchangeId")]
        public string ExchangeId { get; protected set; }

        /// <summary>
        /// Type of symbol (possible values are: SPOT, FUTURES or OPTION).
        /// </summary>
        /// <remarks>
        /// There is a more convenient property "TradeType".
        /// </remarks>
        [DeserializeAs(Name = "tradeType")]
        public string TradeTypeAsString { get; protected set; }

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
        /// Unique symbol identification string (UID).
        /// </summary>
        [DeserializeAs(Name = "_id")]
        public string Id { get; protected set; }

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

        public override string ToString()
        {
            return $"{Name}";
        }

        #region IEquatable<Symbol>

        public bool Equals(Symbol other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Name, other.Name) && string.Equals(ExchangeId, other.ExchangeId) &&
                string.Equals(TradeTypeAsString, other.TradeTypeAsString) && string.Equals(BaseAsset, other.BaseAsset) &&
                string.Equals(QuoteAsset, other.QuoteAsset) && string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((Symbol)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name != null ? Name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (ExchangeId != null ? ExchangeId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TradeTypeAsString != null ? TradeTypeAsString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BaseAsset != null ? BaseAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (QuoteAsset != null ? QuoteAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<Symbol>
    }
}