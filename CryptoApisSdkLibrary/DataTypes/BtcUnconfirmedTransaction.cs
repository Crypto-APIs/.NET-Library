using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class BtcUnconfirmedTransaction : IEquatable<BtcUnconfirmedTransaction>
    {
        [DeserializeAs(Name = "txid")]
        public string Id { get; protected set; }

        [DeserializeAs(Name = "hash")]
        public string Hash { get; protected set; }

        [DeserializeAs(Name = "version")]
        public int Version { get; protected set; }

        [DeserializeAs(Name = "size")]
        public int Size { get; protected set; }

        [DeserializeAs(Name = "vsize")]
        public int VSize { get; protected set; }

        [DeserializeAs(Name = "locktime")]
        public int Locktime { get; protected set; }

        [DeserializeAs(Name = "time")]
        public string Time { get; protected set; }

        [DeserializeAs(Name = "timestamp")]
        public DateTime Timestamp { get; protected set; }

        [DeserializeAs(Name = "txins")]
        public List<TxIns> TxIns { get; protected set; } = new List<TxIns>();

        [DeserializeAs(Name = "txouts")]
        public List<TxOuts> TxOuts { get; protected set; } = new List<TxOuts>();

        #region IEquatable<BtcUnconfirmedTransaction>

        public bool Equals(BtcUnconfirmedTransaction other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Id, other.Id) && string.Equals(Hash, other.Hash)
                   && Version == other.Version && Size == other.Size && VSize == other.VSize
                   && Locktime == other.Locktime && string.Equals(Time, other.Time)
                   && Timestamp.Equals(other.Timestamp)
                   && TxIns.SequenceEqual(other.TxIns) && TxOuts.SequenceEqual(other.TxOuts);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is BtcUnconfirmedTransaction && Equals((BtcUnconfirmedTransaction)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Hash != null ? Hash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Version;
                hashCode = (hashCode * 397) ^ Size;
                hashCode = (hashCode * 397) ^ VSize;
                hashCode = (hashCode * 397) ^ Locktime;
                hashCode = (hashCode * 397) ^ (Time != null ? Time.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Timestamp.GetHashCode();
                hashCode = (hashCode * 397) ^ (TxIns != null ? TxIns.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TxOuts != null ? TxOuts.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<BtcUnconfirmedTransaction>
    }

    public class TxIns : IEquatable<TxIns>
    {
        [DeserializeAs(Name = "txout")]
        public string Txout { get; protected set; }

        [DeserializeAs(Name = "vout")]
        public int VOut { get; protected set; }

        [DeserializeAs(Name = "amount")]
        public string Amount { get; protected set; }

        [DeserializeAs(Name = "coinbase")]
        public string Coinbase { get; protected set; }

        [DeserializeAs(Name = "addresses")]
        public List<string> Addresses { get; protected set; } = new List<string>();

        [DeserializeAs(Name = "votype")]
        public string Votype { get; protected set; }

        [DeserializeAs(Name = "script")]
        public Script Script { get; protected set; }

        #region IEquatable<TxIns>

        public bool Equals(TxIns other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Txout, other.Txout) && VOut == other.VOut && string.Equals(Amount, other.Amount)
                && string.Equals(Coinbase, other.Coinbase)
                && Addresses.SequenceEqual(other.Addresses) && string.Equals(Votype, other.Votype) && Equals(Script, other.Script);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is TxIns && Equals((TxIns)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Txout != null ? Txout.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ VOut;
                hashCode = (hashCode * 397) ^ (Amount != null ? Amount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Coinbase != null ? Coinbase.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Addresses != null ? Addresses.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Votype != null ? Votype.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Script != null ? Script.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<TxIns>
    }

    public class TxOuts : IEquatable<TxOuts>
    {
        [DeserializeAs(Name = "amount")]
        public string Amount { get; protected set; }

        [DeserializeAs(Name = "type")]
        public string Type { get; protected set; }

        [DeserializeAs(Name = "spent")]
        public bool Spent { get; protected set; }

        [DeserializeAs(Name = "addresses")]
        public List<string> Addresses { get; protected set; } = new List<string>();

        [DeserializeAs(Name = "script")]
        public Script Script { get; protected set; }

        #region IEquatable<TxOuts>

        public bool Equals(TxOuts other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Amount, other.Amount) && string.Equals(Type, other.Type) && Spent == other.Spent
                && Addresses.SequenceEqual(other.Addresses) && Equals(Script, other.Script);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is TxOuts && Equals((TxOuts)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Amount != null ? Amount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Spent.GetHashCode();
                hashCode = (hashCode * 397) ^ (Addresses != null ? Addresses.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Script != null ? Script.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<TxOuts>
    }

    public class Script : IEquatable<Script>
    {
        [DeserializeAs(Name = "asm")]
        public string Asm { get; protected set; }

        [DeserializeAs(Name = "hex")]
        public string Hex { get; protected set; }

        [DeserializeAs(Name = "reqsigs")]
        public int? Reqsigs { get; protected set; }

        #region IEquatable<Script>

        public bool Equals(Script other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Asm, other.Asm) && string.Equals(Hex, other.Hex) && Reqsigs == other.Reqsigs;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == this.GetType() && Equals((Script)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Asm != null ? Asm.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Hex != null ? Hex.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Reqsigs.GetHashCode();
                return hashCode;
            }
        }

        #endregion IEquatable<Script>
    }
}