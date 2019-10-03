using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class Ohlcv : IEquatable<Ohlcv>
    {
        /// <summary>
        /// Exchange where symbol is traded.
        /// </summary>
        [DeserializeAs(Name = "exchange")]
        public string ExchangeId { get; protected set; }

        /// <summary>
        /// Type of symbol (possible values are: SPOT, FUTURES or OPTION).
        /// </summary>
        [DeserializeAs(Name = "eventType")]
        public string TradeType { get; protected set; }

        /// <summary>
        /// FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).
        /// </summary>
        [DeserializeAs(Name = "assetBase")]
        public string BaseAsset { get; protected set; }

        /// <summary>
        /// FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).
        /// </summary>
        [DeserializeAs(Name = "assetQuote")]
        public string QuoteAsset { get; protected set; }

        /// <summary>
        /// Period starting time (range left inclusive).
        /// </summary>
        [DeserializeAs(Name = "timePeriodStart")]
        public DateTime TimePeriodStart { get; protected set; }

        /// <summary>
        /// Period ending time (range right exclusive).
        /// </summary>
        [DeserializeAs(Name = "timePeriodEnd")]
        public DateTime TimePeriodEnd { get; protected set; }

        /// <summary>
        /// Time of first trade inside period range.
        /// </summary>
        [DeserializeAs(Name = "timeOpen")]
        public DateTime TimeOpen { get; protected set; }

        /// <summary>
        /// Time of last trade inside period range.
        /// </summary>
        [DeserializeAs(Name = "timeClose")]
        public DateTime TimeClose { get; protected set; }

        /// <summary>
        /// First trade price inside period range.
        /// </summary>
        [DeserializeAs(Name = "priceOpen")]
        public double PriceOpen { get; protected set; }

        /// <summary>
        /// Last trade price inside period range.
        /// </summary>
        [DeserializeAs(Name = "priceClose")]
        public double PriceClose { get; protected set; }

        /// <summary>
        /// Lowest traded price inside period range.
        /// </summary>
        [DeserializeAs(Name = "priceLow")]
        public double PriceLow { get; protected set; }

        /// <summary>
        /// Highest traded price inside period range.
        /// </summary>
        [DeserializeAs(Name = "priceHigh")]
        public double PriceHigh { get; protected set; }

        /// <summary>
        /// Cumulative base amount traded inside period range.
        /// </summary>
        [DeserializeAs(Name = "volumeTraded")]
        public double VolumeTraded { get; protected set; }

        /// <summary>
        /// Amount of trades executed inside period range.
        /// </summary>
        [DeserializeAs(Name = "tradesCount")]
        public double TradesCount { get; protected set; }

        /// <summary>
        /// Service field - Id.
        /// </summary>
        [DeserializeAs(Name = "_id")]
        public string Id { get; protected set; }

        #region IEquatable<Ohlcv>

        public bool Equals(Ohlcv other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(ExchangeId, other.ExchangeId) && string.Equals(TradeType, other.TradeType) &&
                string.Equals(BaseAsset, other.BaseAsset) && string.Equals(QuoteAsset, other.QuoteAsset) &&
                TimePeriodStart.Equals(other.TimePeriodStart) && TimePeriodEnd.Equals(other.TimePeriodEnd) &&
                TimeOpen.Equals(other.TimeOpen) && TimeClose.Equals(other.TimeClose) && PriceOpen.Equals(other.PriceOpen) &&
                PriceClose.Equals(other.PriceClose) && PriceLow.Equals(other.PriceLow) && PriceHigh.Equals(other.PriceHigh) &&
                VolumeTraded.Equals(other.VolumeTraded) && TradesCount.Equals(other.TradesCount) && string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((Ohlcv)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ExchangeId != null ? ExchangeId.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (TradeType != null ? TradeType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BaseAsset != null ? BaseAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (QuoteAsset != null ? QuoteAsset.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TimePeriodStart.GetHashCode();
                hashCode = (hashCode * 397) ^ TimePeriodEnd.GetHashCode();
                hashCode = (hashCode * 397) ^ TimeOpen.GetHashCode();
                hashCode = (hashCode * 397) ^ TimeClose.GetHashCode();
                hashCode = (hashCode * 397) ^ PriceOpen.GetHashCode();
                hashCode = (hashCode * 397) ^ PriceClose.GetHashCode();
                hashCode = (hashCode * 397) ^ PriceLow.GetHashCode();
                hashCode = (hashCode * 397) ^ PriceHigh.GetHashCode();
                hashCode = (hashCode * 397) ^ VolumeTraded.GetHashCode();
                hashCode = (hashCode * 397) ^ TradesCount.GetHashCode();
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<Ohlcv>
    }
}