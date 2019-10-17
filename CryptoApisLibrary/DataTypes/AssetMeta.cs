using RestSharp.Deserializers;
using System;

namespace CryptoApisLibrary.DataTypes
{
    public class AssetMeta : IEquatable<AssetMeta>
    {
        /// <summary>
        /// Default constructor need for serialization/deserialization.
        /// </summary>
        public AssetMeta()
        { }

        public AssetMeta(string id) : this()
        {
            Id = id;
        }

        /// <summary>
        /// Asset identifier.
        /// </summary>
        [DeserializeAs(Name = "assetId")]
        public string AssetId { get; set; }

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
        /// Boolean value transported as integer; True for cryptocurrency assets, False otherwise.
        /// </summary>
        [DeserializeAs(Name = "cryptoType")]
        public bool CryptoType { get; protected set; }

        /// <summary>
        /// Unique asset identification string (UID).
        /// </summary>
        [DeserializeAs(Name = "_id")]
        public string Id { get; protected set; }

        public override string ToString()
        {
            return AssetId;
        }

        #region IEquatable<Asset>

        public bool Equals(AssetMeta other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return AssetId == other.AssetId && OriginalSymbol == other.OriginalSymbol &&
                   Name == other.Name && CryptoType == other.CryptoType && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((AssetMeta)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AssetId != null ? AssetId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OriginalSymbol != null ? OriginalSymbol.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CryptoType.GetHashCode();
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<Asset>
    }
}