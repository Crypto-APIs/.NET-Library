using RestSharp.Deserializers;
using System;

namespace CryptoApisLibrary.DataTypes
{
    public class EthTransaction : IEquatable<EthTransaction>
    {
        [DeserializeAs(Name = "from")]
        public string From { get; protected set; }

        [DeserializeAs(Name = "to")]
        public string To { get; protected set; }

        [DeserializeAs(Name = "hash")]
        public string Hash { get; protected set; }

        [DeserializeAs(Name = "value")]
        public string Value { get; protected set; }

        [DeserializeAs(Name = "timestamp")]
        public string Timestamp { get; protected set; }

        [DeserializeAs(Name = "nonce")]
        public long Nonce { get; protected set; }

        [DeserializeAs(Name = "confirmations")]
        public long Confirmations { get; protected set; }

        #region IEquatable<EthTransaction>

        public bool Equals(EthTransaction other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(From, other.From) && string.Equals(To, other.To) && string.Equals(Hash, other.Hash)
                && Value.Equals(other.Value) && string.Equals(Timestamp, other.Timestamp) && Nonce == other.Nonce
                && Confirmations == other.Confirmations;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == this.GetType() && Equals((EthTransaction)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (From != null ? From.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (To != null ? To.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Hash != null ? Hash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
                hashCode = (hashCode * 397) ^ (Timestamp != null ? Timestamp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Nonce.GetHashCode();
                hashCode = (hashCode * 397) ^ Confirmations.GetHashCode();
                return hashCode;
            }
        }

        #endregion IEquatable<EthTransaction>
    }
}