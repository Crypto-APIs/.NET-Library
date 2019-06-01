using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class Exchange : IEquatable<Exchange>
    {
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
        /// Exchange website address.
        /// </summary>
        [DeserializeAs(Name = "website")]
        public string Website { get; protected set; }

        /// <summary>
        /// Unique exchange identification string (UID).
        /// </summary>
        [DeserializeAs(Name = "_id")]
        public string Id { get; protected set; }

        #region IEquatable<Exchange>

        public bool Equals(Exchange other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(ExchangeId, other.ExchangeId) && string.Equals(Name, other.Name) &&
                string.Equals(Website, other.Website) && string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is Exchange && Equals((Exchange)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ExchangeId != null ? ExchangeId.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Website != null ? Website.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<Exchange>
    }
}