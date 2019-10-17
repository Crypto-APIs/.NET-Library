using RestSharp.Deserializers;
using System;

namespace CryptoApisLibrary.DataTypes
{
    public class BtcTransaction : BtcUnconfirmedTransaction, IEquatable<BtcTransaction>
    {
        [DeserializeAs(Name = "index")]
        public int Index { get; protected set; }

        [DeserializeAs(Name = "blockhash")]
        public string BlockHash { get; protected set; }

        [DeserializeAs(Name = "blockheight")]
        public long BlockHeight { get; protected set; }

        [DeserializeAs(Name = "blocktime")]
        public string BlockTime { get; protected set; }

        [DeserializeAs(Name = "confirmations")]
        public int Confirmations { get; protected set; }

        #region IEquatable<BtcTransaction>

        public bool Equals(BtcTransaction other)
        {
            var equals = base.Equals(other);
            if (!equals)
                return false;

            return Index == other.Index
                   && string.Equals(BlockHash, other.BlockHash) && BlockHeight == other.BlockHeight
                   && string.Equals(BlockTime, other.BlockTime)
                   && Confirmations == other.Confirmations;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is BtcTransaction && Equals((BtcTransaction)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var baseHashCode = base.GetHashCode();

                var hashCode = baseHashCode;
                hashCode = (hashCode * 397) ^ Index;
                hashCode = (hashCode * 397) ^ (BlockHash != null ? BlockHash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ BlockHeight.GetHashCode();
                hashCode = (hashCode * 397) ^ (BlockTime != null ? BlockTime.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Confirmations;
                return hashCode;
            }
        }

        #endregion IEquatable<BtcTransaction>
    }
}