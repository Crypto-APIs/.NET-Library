using RestSharp.Deserializers;
using System;

namespace CryptoApisLibrary.DataTypes
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
        /// Volume for the last 24 hours.
        /// </summary>
        [DeserializeAs(Name = "volume")]
        public double Volume { get; protected set; }

        /// <summary>
        /// Volume change percentage for the last 24 hours.
        /// </summary>
        [DeserializeAs(Name = "change")]
        public double Change { get; protected set; }

        /// <summary>
        /// Number of markets supported.
        /// </summary>
        [DeserializeAs(Name = "markets")]
        public int Markets { get; protected set; }

        /// <summary>
        /// Display name of the exchange.
        /// </summary>
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Unique exchange identification string (UID).
        /// </summary>
        [DeserializeAs(Name = "_id")]
        public string Id { get; protected set; }

        public Exchange ToExchange => new Exchange(Id);

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
            return Volume.Equals(other.Volume) && Change.Equals(other.Change) &&
                   Markets == other.Markets && Name == other.Name && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((ExchangeMeta)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Volume.GetHashCode();
                hashCode = (hashCode * 397) ^ Change.GetHashCode();
                hashCode = (hashCode * 397) ^ Markets;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<ExchangeMeta>
    }
}