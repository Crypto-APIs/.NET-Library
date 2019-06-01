using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class Asset : IEquatable<Asset>
    {
        /// <summary>
        /// Asset identifier.
        /// </summary>
        [DeserializeAs(Name = "assetId")]
        public string AssetId { get; protected set; }

        /// <summary>
        /// Original asset name as listed originally by creator / issuer.
        /// </summary>
        [DeserializeAs(Name = "originalSymbol")]
        public string OriginalSymbol { get; protected set; }

        /// <summary>
        /// Display name of the asset.
        /// </summary>
        [DeserializeAs(Name = "name")]
        public string Name { get; protected set; }

        /// <summary>
        /// Lowercase and without whitespaces representation of the name of the asset.
        /// </summary>
        [DeserializeAs(Name = "slug")]
        public string Slug { get; protected set; }

        /// <summary>
        /// Boolean value transported as integer; True for cryptocurrency assets, False otherwise.
        /// </summary>
        [DeserializeAs(Name = "cryptoType")]
        public bool CryptoType { get; protected set; }

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
        /// Unique asset identification string (UID).
        /// </summary>
        [DeserializeAs(Name = "_id")]
        public string Id { get; protected set; }

        public Asset()
        {
        }

        public Asset(string assetId)
        {
            AssetId = assetId;
        }

        public override string ToString()
        {
            return AssetId;
        }

        #region IEquatable<Asset>

        public bool Equals(Asset other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(AssetId, other.AssetId) && string.Equals(OriginalSymbol, other.OriginalSymbol) &&
                string.Equals(Name, other.Name) && string.Equals(Slug, other.Slug) && CryptoType == other.CryptoType &&
                Supply.Equals(other.Supply) && MarketCap.Equals(other.MarketCap) && Price.Equals(other.Price) &&
                Volume.Equals(other.Volume) && Change.Equals(other.Change) && string.Equals(Id, other.Id);
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
                var hashCode = AssetId != null ? AssetId.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (OriginalSymbol != null ? OriginalSymbol.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Slug != null ? Slug.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CryptoType.GetHashCode();
                hashCode = (hashCode * 397) ^ Supply.GetHashCode();
                hashCode = (hashCode * 397) ^ MarketCap.GetHashCode();
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ Volume.GetHashCode();
                hashCode = (hashCode * 397) ^ Change.GetHashCode();
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<Asset>
    }
}