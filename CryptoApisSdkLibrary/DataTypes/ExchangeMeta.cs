using System;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class ExchangeMeta : IEquatable<ExchangeMeta>
    {
        /// <summary>
        /// Default constructor need for serialization/deserialization.
        /// </summary>
        public ExchangeMeta()
        { }

        public ExchangeMeta(string id) : this()
        {
            Id = id;
        }

        /// <summary>
        /// Exchange identifier.
        /// </summary>
        [DeserializeAs(Name = "exchangeId")]
        public string ExchangeId { get; protected set; }

        /// <summary>
        /// Display name of the exchange.
        /// </summary>
        [DeserializeAs(Name = "name")]
        public string Name { get; protected set; }

        /// <summary>
        /// Unique exchange identification string (UID).
        /// </summary>
        [DeserializeAs(Name = "_id")]
        public string Id { get; protected set; }

        public override string ToString()
        {
            return Name;
        }

        #region IEquatable<ExchangeMeta>

        public bool Equals(ExchangeMeta other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(ExchangeId, other.ExchangeId) && string.Equals(Name, other.Name) &&
                   string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is ExchangeMeta && Equals((ExchangeMeta)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ExchangeId != null ? ExchangeId.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<ExchangeMeta>
    }
}