using RestSharp.Deserializers;
using System;

namespace CryptoApisLibrary.DataTypes
{
    public class Asset : AssetMeta, IEquatable<Asset>
    {
        /// <summary>
        /// Default constructor need for serialization/deserialization.
        /// </summary>
        public Asset()
        { }

        public Asset(string id) : base(id)
        {
        }

        /// <summary>
        /// Lowercase and without whitespaces representation of the name of the asset.
        /// </summary>
        [DeserializeAs(Name = "slug")]
        public string Slug { get; protected set; }

        /// <summary>
        /// Approximate total amount of coins in existence right now. Applicable only for currencies of type crypto.
        /// </summary>
        [DeserializeAs(Name = "supply")]
        public double Supply { get; protected set; }

        /// <summary>
        /// Market capitalization in USD. Applicable only for currencies of type crypto.
        /// </summary>
        [DeserializeAs(Name = "marketCap")]
        public double MarketCap { get; protected set; }

        /// <summary>
        /// Latest weighted average trade price across markets in USD. Applicable only for currencies of type crypto.
        /// </summary>
        [DeserializeAs(Name = "price")]
        public double Price { get; protected set; }

        /// <summary>
        /// 24 hour trading volume in USD. Applicable only for currencies of type crypto.
        /// </summary>
        [DeserializeAs(Name = "volume")]
        public double Volume { get; protected set; }

        /// <summary>
        /// 24 hour trading price percentage change. Applicable only for currencies of type crypto.
        /// </summary>
        [DeserializeAs(Name = "change")]
        public double Change { get; protected set; }

        /// <summary>
        /// 1 hour trading price percentage change.
        /// </summary>
        [DeserializeAs(Name = "change1Hour")]
        public double Change1Hour { get; protected set; }

        /// <summary>
        /// 1 week trading price percentage change.
        /// </summary>
        [DeserializeAs(Name = "change1Week")]
        public double Change1Week { get; protected set; }

        /// <summary>
        /// The highest trading price in USD.
        /// </summary>
        [DeserializeAs(Name = "allTimeHigh")]
        public double AllTimeHigh { get; protected set; }

        /// <summary>
        /// The lowest trading price in USD.
        /// </summary>
        [DeserializeAs(Name = "allTimeLow")]
        public double AllTimeLow { get; protected set; }

        /// <summary>
        /// The first trading price in USD.
        /// </summary>
        [DeserializeAs(Name = "earliestKnownPrice")]
        public double EarliestKnownPrice { get; protected set; }

        /// <summary>
        /// UNIX Timestamp of the date of the first trade.
        /// </summary>
        [DeserializeAs(Name = "earliestTradeDate")]
        public double EarliestTradeDate { get; protected set; }

        /// <summary>
        /// Object holding meta information about currency logo e.g. mime type, and base64 encoded image data, etc.
        /// </summary>
        [DeserializeAs(Name = "logo")]
        public Logo Logo { get; protected set; }

        #region IEquatable<Asset>

        public bool Equals(Asset other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return base.Equals(other) && Slug == other.Slug && Supply.Equals(other.Supply) &&
                   MarketCap.Equals(other.MarketCap) && Price.Equals(other.Price) &&
                   Volume.Equals(other.Volume) && Change.Equals(other.Change) &&
                   Change1Hour.Equals(other.Change1Hour) && Change1Week.Equals(other.Change1Week) &&
                   AllTimeHigh.Equals(other.AllTimeHigh) && AllTimeLow.Equals(other.AllTimeLow) &&
                   EarliestKnownPrice.Equals(other.EarliestKnownPrice) &&
                   EarliestTradeDate.Equals(other.EarliestTradeDate) && Equals(Logo, other.Logo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((Asset)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Slug != null ? Slug.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Supply.GetHashCode();
                hashCode = (hashCode * 397) ^ MarketCap.GetHashCode();
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ Volume.GetHashCode();
                hashCode = (hashCode * 397) ^ Change.GetHashCode();
                hashCode = (hashCode * 397) ^ Change1Hour.GetHashCode();
                hashCode = (hashCode * 397) ^ Change1Week.GetHashCode();
                hashCode = (hashCode * 397) ^ AllTimeHigh.GetHashCode();
                hashCode = (hashCode * 397) ^ AllTimeLow.GetHashCode();
                hashCode = (hashCode * 397) ^ EarliestKnownPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ EarliestTradeDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (Logo != null ? Logo.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<Asset>
    }
}