using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisLibrary.ResponseTypes.Blockchains.Payloads
{
    public abstract class GetAddressPayload
    {
        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }
    }

    public class GetBtcAddressPayload : GetAddressPayload, IEquatable<GetBtcAddressPayload>
    {
        [DeserializeAs(Name = "totalSpent")]
        public string TotalSpent { get; protected set; }

        [DeserializeAs(Name = "totalReceived")]
        public string TotalReceived { get; protected set; }

        [DeserializeAs(Name = "balance")]
        public string Balance { get; protected set; }

        [DeserializeAs(Name = "txi")]
        public int Txi { get; protected set; }

        [DeserializeAs(Name = "txo")]
        public int Txo { get; protected set; }

        [DeserializeAs(Name = "txsCount")]
        public int TxsCount { get; protected set; }

        /// <summary>
        /// Applied only for BCH.
        /// </summary>
        [DeserializeAs(Name = "legacy")]
        public string Legacy { get; protected set; }

        [DeserializeAs(Name = "addresses")]
        public List<string> Addresses { get; protected set; } = new List<string>();

        #region IEquatable<GetBtcAddressPayload>

        public bool Equals(GetBtcAddressPayload other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return TotalSpent.Equals(other.TotalSpent) && TotalReceived.Equals(other.TotalReceived)
                && Balance.Equals(other.Balance) && Txi == other.Txi && Txo == other.Txo
                && TxsCount == other.TxsCount && string.Equals(Legacy, other.Legacy)
                && Addresses.SequenceEqual(other.Addresses);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == this.GetType() && Equals((GetBtcAddressPayload)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TotalSpent.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalReceived.GetHashCode();
                hashCode = (hashCode * 397) ^ Balance.GetHashCode();
                hashCode = (hashCode * 397) ^ Txi;
                hashCode = (hashCode * 397) ^ Txo;
                hashCode = (hashCode * 397) ^ TxsCount;
                hashCode = (hashCode * 397) ^ (Legacy != null ? Legacy.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Addresses != null ? Addresses.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<GetBtcAddressPayload>
    }

    public class GetEthAddressPayload : GetAddressPayload, IEquatable<GetEthAddressPayload>
    {
        [DeserializeAs(Name = "chain")]
        public string Chain { get; protected set; }

        [DeserializeAs(Name = "balance")]
        public double Balance { get; protected set; }

        [DeserializeAs(Name = "txs_count")]
        public int TxsCount { get; protected set; }

        [DeserializeAs(Name = "from")]
        public int From { get; protected set; }

        [DeserializeAs(Name = "to")]
        public int To { get; protected set; }

        #region IEquatable<GetEthAddressPayload>

        public bool Equals(GetEthAddressPayload other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Chain, other.Chain) && Balance.Equals(other.Balance)
                                                     && TxsCount == other.TxsCount && From == other.From && To == other.To;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == this.GetType() && Equals((GetEthAddressPayload)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Chain != null ? Chain.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Balance.GetHashCode();
                hashCode = (hashCode * 397) ^ TxsCount;
                hashCode = (hashCode * 397) ^ From;
                hashCode = (hashCode * 397) ^ To;
                return hashCode;
            }
        }

        #endregion IEquatable<GetEthAddressPayload>
    }
}