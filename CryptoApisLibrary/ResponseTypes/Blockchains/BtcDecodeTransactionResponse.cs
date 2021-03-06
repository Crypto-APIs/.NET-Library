﻿using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class BtcDecodeTransactionResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Payload Transaction { get; protected set; }

        public class Payload : IEquatable<Payload>
        {
            [DeserializeAs(Name = "txid")]
            public string TransactionId { get; protected set; }

            [DeserializeAs(Name = "hash")]
            public string Hash { get; protected set; }

            [DeserializeAs(Name = "size")]
            public long Size { get; protected set; }

            [DeserializeAs(Name = "vsize")]
            public long? Vsize { get; protected set; }

            [DeserializeAs(Name = "version")]
            public long Version { get; protected set; }

            [DeserializeAs(Name = "locktime")]
            public long LockTime { get; protected set; }

            [DeserializeAs(Name = "blockhash")]
            public string Blockhash { get; protected set; }

            [DeserializeAs(Name = "blockNumber")]
            public long? BlockNumber { get; protected set; }

            [DeserializeAs(Name = "confirmations")]
            public long? Confirmations { get; protected set; }

            [DeserializeAs(Name = "time")]
            public string Time { get; protected set; }

            [DeserializeAs(Name = "vin")]
            public List<Vin> VIn { get; protected set; } = new List<Vin>();

            [DeserializeAs(Name = "vout")]
            public List<Vout> VOut { get; protected set; } = new List<Vout>();

            #region IEquatable<ResponsePayload>

            public bool Equals(Payload other)
            {
                if (ReferenceEquals(null, other))
                    return false;
                if (ReferenceEquals(this, other))
                    return true;
                return string.Equals(TransactionId, other.TransactionId) && string.Equals(Hash, other.Hash)
                    && Size == other.Size && Vsize == other.Vsize && Version == other.Version && LockTime == other.LockTime
                    && string.Equals(Blockhash, other.Blockhash) && BlockNumber == other.BlockNumber
                    && Confirmations == other.Confirmations && string.Equals(Time, other.Time)
                    && VIn.SequenceEqual(other.VIn) && VOut.SequenceEqual(other.VOut);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                return obj.GetType() == this.GetType() && Equals((Payload)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (TransactionId != null ? TransactionId.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Hash != null ? Hash.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ Size.GetHashCode();
                    hashCode = (hashCode * 397) ^ Vsize.GetHashCode();
                    hashCode = (hashCode * 397) ^ Version.GetHashCode();
                    hashCode = (hashCode * 397) ^ LockTime.GetHashCode();
                    hashCode = (hashCode * 397) ^ (Blockhash != null ? Blockhash.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ BlockNumber.GetHashCode();
                    hashCode = (hashCode * 397) ^ Confirmations.GetHashCode();
                    hashCode = (hashCode * 397) ^ (Time != null ? Time.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (VIn != null ? VIn.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (VOut != null ? VOut.GetHashCode() : 0);
                    return hashCode;
                }
            }

            #endregion IEquatable<Response>

            public class Vin : IEquatable<Vin>
            {
                [DeserializeAs(Name = "txid")]
                public string TransactionId { get; protected set; }

                [DeserializeAs(Name = "sequence")]
                public long Sequence { get; protected set; }

                [DeserializeAs(Name = "vout")]
                public long Vout { get; protected set; }

                [DeserializeAs(Name = "scriptSig")]
                public Scriptsig ScriptSig { get; protected set; }

                [DeserializeAs(Name = "addresses")]
                public List<string> Addresses { get; protected set; } = new List<string>();

                [DeserializeAs(Name = "value")]
                public string Value { get; protected set; }

                #region IEquatable<Vin>

                public bool Equals(Vin other)
                {
                    if (ReferenceEquals(null, other))
                        return false;
                    if (ReferenceEquals(this, other))
                        return true;
                    return string.Equals(TransactionId, other.TransactionId) && Sequence == other.Sequence
                        && Vout == other.Vout && Equals(ScriptSig, other.ScriptSig)
                        && Addresses.SequenceEqual(other.Addresses) && string.Equals(Value, other.Value);
                }

                public override bool Equals(object obj)
                {
                    if (ReferenceEquals(null, obj))
                        return false;
                    if (ReferenceEquals(this, obj))
                        return true;
                    return obj.GetType() == this.GetType() && Equals((Vin)obj);
                }

                public override int GetHashCode()
                {
                    unchecked
                    {
                        var hashCode = (TransactionId != null ? TransactionId.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ Sequence.GetHashCode();
                        hashCode = (hashCode * 397) ^ Vout.GetHashCode();
                        hashCode = (hashCode * 397) ^ (ScriptSig != null ? ScriptSig.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (Addresses != null ? Addresses.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                        return hashCode;
                    }
                }

                #endregion IEquatable<Vin>

                public class Scriptsig : IEquatable<Scriptsig>
                {
                    [DeserializeAs(Name = "asm")]
                    public string Asm { get; protected set; }

                    [DeserializeAs(Name = "hex")]
                    public string Hex { get; protected set; }

                    #region IEquatable<Scriptsig>

                    public bool Equals(Scriptsig other)
                    {
                        if (ReferenceEquals(null, other))
                            return false;
                        if (ReferenceEquals(this, other))
                            return true;
                        return string.Equals(Asm, other.Asm) && string.Equals(Hex, other.Hex);
                    }

                    public override bool Equals(object obj)
                    {
                        if (ReferenceEquals(null, obj))
                            return false;
                        if (ReferenceEquals(this, obj))
                            return true;
                        return obj.GetType() == this.GetType() && Equals((Scriptsig)obj);
                    }

                    public override int GetHashCode()
                    {
                        unchecked
                        {
                            return ((Asm != null ? Asm.GetHashCode() : 0) * 397) ^ (Hex != null ? Hex.GetHashCode() : 0);
                        }
                    }

                    #endregion IEquatable<Scriptsig>
                }
            }

            public class Vout : IEquatable<Vout>
            {
                [DeserializeAs(Name = "value")]
                public string Value { get; protected set; }

                [DeserializeAs(Name = "n")]
                public long N { get; protected set; }

                [DeserializeAs(Name = "scriptPubKey")]
                public ScriptPubKey ScriptPublicKey { get; protected set; }

                #region IEquatable<Vout>

                public bool Equals(Vout other)
                {
                    if (ReferenceEquals(null, other))
                        return false;
                    if (ReferenceEquals(this, other))
                        return true;
                    return string.Equals(Value, other.Value) && N == other.N && Equals(ScriptPublicKey, other.ScriptPublicKey);
                }

                public override bool Equals(object obj)
                {
                    if (ReferenceEquals(null, obj))
                        return false;
                    if (ReferenceEquals(this, obj))
                        return true;
                    return obj.GetType() == this.GetType() && Equals((Vout)obj);
                }

                public override int GetHashCode()
                {
                    unchecked
                    {
                        var hashCode = (Value != null ? Value.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ N.GetHashCode();
                        hashCode = (hashCode * 397) ^ (ScriptPublicKey != null ? ScriptPublicKey.GetHashCode() : 0);
                        return hashCode;
                    }
                }

                #endregion IEquatable<Vout>

                public class ScriptPubKey : IEquatable<ScriptPubKey>
                {
                    [DeserializeAs(Name = "asm")]
                    public string Asm { get; protected set; }

                    [DeserializeAs(Name = "hex")]
                    public string Hex { get; protected set; }

                    [DeserializeAs(Name = "reqSigs")]
                    public long ReqSigs { get; protected set; }

                    [DeserializeAs(Name = "type")]
                    public string Type { get; protected set; }

                    [DeserializeAs(Name = "addresses")]
                    public List<string> Addresses { get; protected set; } = new List<string>();

                    #region IEquatable<ScriptPubKey>

                    public bool Equals(ScriptPubKey other)
                    {
                        if (ReferenceEquals(null, other))
                            return false;
                        if (ReferenceEquals(this, other))
                            return true;
                        return string.Equals(Asm, other.Asm) && string.Equals(Hex, other.Hex) && ReqSigs == other.ReqSigs
                               && string.Equals(Type, other.Type) && Addresses.SequenceEqual(other.Addresses);
                    }

                    public override bool Equals(object obj)
                    {
                        if (ReferenceEquals(null, obj))
                            return false;
                        if (ReferenceEquals(this, obj))
                            return true;
                        return obj.GetType() == this.GetType() && Equals((ScriptPubKey)obj);
                    }

                    public override int GetHashCode()
                    {
                        unchecked
                        {
                            var hashCode = (Asm != null ? Asm.GetHashCode() : 0);
                            hashCode = (hashCode * 397) ^ (Hex != null ? Hex.GetHashCode() : 0);
                            hashCode = (hashCode * 397) ^ ReqSigs.GetHashCode();
                            hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                            hashCode = (hashCode * 397) ^ (Addresses != null ? Addresses.GetHashCode() : 0);
                            return hashCode;
                        }
                    }

                    #endregion IEquatable<ScriptPubKey>
                }
            }
        }
    }
}