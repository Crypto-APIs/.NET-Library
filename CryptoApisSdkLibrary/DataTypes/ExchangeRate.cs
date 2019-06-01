using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class ExchangeRate : IEquatable<ExchangeRate>
    {
        /// <summary>
        /// Exchange rate between assets calculated by weighted average of the last trades in every exchange
        /// for the last 24 hours by giving more weight to exchanges with higher volume.
        /// </summary>
        [DeserializeAs(Name = "weightedAveragePrice")]
        public double WeightedAveragePrice { get; protected set; }

        /// <summary>
        /// Exchange rate between assets calculated by median of the last trades in every exchange for the last 24 hours.
        /// </summary>
        [DeserializeAs(Name = "medianPrice")]
        public double MedianPrice { get; protected set; }

        /// <summary>
        /// Exchange rate between assets calculated by median of the last trades in every exchange for the last 24 hours
        /// by giving more weight to exchanges with higher volume.
        /// Range of the prices is being adjusted by calculating percentage of wrong (extremely low or extremely high) prices.
        /// </summary>
        [DeserializeAs(Name = "weightedMedianAveragePrice")]
        public double WeightedMedianAveragePrice { get; protected set; }

        /// <summary>
        /// FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).
        /// </summary>
        [DeserializeAs(Name = "baseAsset")]
        public string BaseAssetId { get; protected set; }

        /// <summary>
        /// FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).
        /// </summary>
        [DeserializeAs(Name = "quoteAsset")]
        public string QuoteAssetId { get; protected set; }

        /// <summary>
        /// Time (in UNIX Timestamp) of the market data used to calculate exchange rate.
        /// </summary>
        [DeserializeAs(Name = "timestamp")]
        public DateTime Timestamp { get; protected set; }

        #region IEquatable<ExchangeRate>

        public bool Equals(ExchangeRate other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return
                WeightedAveragePrice.Equals(other.WeightedAveragePrice) && MedianPrice.Equals(other.MedianPrice) &&
                WeightedMedianAveragePrice.Equals(other.WeightedMedianAveragePrice) &&
                string.Equals(BaseAssetId, other.BaseAssetId) && string.Equals(QuoteAssetId, other.QuoteAssetId) &&
                Timestamp.Equals(other.Timestamp);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((ExchangeRate)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = WeightedAveragePrice.GetHashCode();
                hashCode = (hashCode * 397) ^ MedianPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ WeightedMedianAveragePrice.GetHashCode();
                hashCode = (hashCode * 397) ^ (BaseAssetId != null ? BaseAssetId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (QuoteAssetId != null ? QuoteAssetId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Timestamp.GetHashCode();
                return hashCode;
            }
        }

        #endregion IEquatable<ExchangeRate>
    }
}