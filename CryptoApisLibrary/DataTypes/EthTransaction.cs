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

        [DeserializeAs(Name = "block")]
        public long Block { get; protected set; }

        [DeserializeAs(Name = "gas_price")]
        public string GasPrice { get; protected set; }

        [DeserializeAs(Name = "gas_used")]
        public string GasUsed { get; protected set; }

        #region IEquatable<EthTransaction>

        public bool Equals(EthTransaction other)
        {
            if (ReferenceEquals(null, other)) 
                return false;
            if (ReferenceEquals(this, other)) 
                return true;
            return From == other.From && To == other.To && Hash == other.Hash && Value == other.Value && 
                   Timestamp == other.Timestamp && Nonce == other.Nonce && Confirmations == other.Confirmations && 
                   Block == other.Block && GasPrice == other.GasPrice && GasUsed == other.GasUsed;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;
            if (ReferenceEquals(this, obj)) 
                return true;
            return obj.GetType() == GetType() && Equals((EthTransaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (From != null ? From.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (To != null ? To.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Hash != null ? Hash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Timestamp != null ? Timestamp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Nonce.GetHashCode();
                hashCode = (hashCode * 397) ^ Confirmations.GetHashCode();
                hashCode = (hashCode * 397) ^ Block.GetHashCode();
                hashCode = (hashCode * 397) ^ (GasPrice != null ? GasPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (GasUsed != null ? GasUsed.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<EthTransaction>
    }
}