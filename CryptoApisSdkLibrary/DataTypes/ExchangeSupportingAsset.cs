using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class ExchangeSupportingAsset : IEquatable<ExchangeSupportingAsset>
    {
        /// <summary>
        /// Unique exchange identification string (UID).
        /// </summary>
        [DeserializeAs(Name = "exchangeId")]
        public string ExchangeId { get; protected set; }

        /// <summary>
        /// Number of pairs in the exchange where asset is supported as base.
        /// </summary>
        [DeserializeAs(Name = "pairsAsBaseCount")]
        public int PairsAsBaseCount { get; protected set; }

        /// <summary>
        /// Number of pairs in the exchange where asset is supported as quote
        /// </summary>
        [DeserializeAs(Name = "pairsAsQuoteCount")]
        public int PairsAsQuoteCount { get; protected set; }

        public override string ToString()
        {
            return ExchangeId;
        }

        #region IEquatable<ExchangeSupportingAsset>

        public bool Equals(ExchangeSupportingAsset other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return ExchangeId == other.ExchangeId && PairsAsBaseCount == other.PairsAsBaseCount &&
                   PairsAsQuoteCount == other.PairsAsQuoteCount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == this.GetType() && Equals((ExchangeSupportingAsset)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ExchangeId != null ? ExchangeId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PairsAsBaseCount;
                hashCode = (hashCode * 397) ^ PairsAsQuoteCount;
                return hashCode;
            }
        }

        #endregion IEquatable<ExchangeSupportingAsset>
    }
}