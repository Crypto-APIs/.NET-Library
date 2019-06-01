using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class EthTransactionInfo : IEquatable<EthTransactionInfo>
    {
        [DeserializeAs(Name = "chain")]
        public string Chain { get; protected set; }

        [DeserializeAs(Name = "token_transfers")]
        public List<TokenTransfers> TokenTransfers { get; protected set; } = new List<TokenTransfers>();

        [DeserializeAs(Name = "status")]
        public string Status { get; protected set; }

        [DeserializeAs(Name = "index")]
        public int Index { get; protected set; }

        [DeserializeAs(Name = "hash")]
        public string TransactionHash { get; protected set; }

        [DeserializeAs(Name = "value")]
        public double Value { get; protected set; }

        [DeserializeAs(Name = "from")]
        public string FromAddress { get; protected set; }

        [DeserializeAs(Name = "to")]
        public string ToAddress { get; protected set; }

        [DeserializeAs(Name = "date")]
        public string Date { get; protected set; }

        [DeserializeAs(Name = "block_hash")]
        public string BlockHash { get; protected set; }

        [DeserializeAs(Name = "block_number")]
        public long BlockNumber { get; protected set; }

        [DeserializeAs(Name = "gas")]
        public long Gas { get; protected set; }

        [DeserializeAs(Name = "gas_price")]
        public long GasPrice { get; protected set; }

        [DeserializeAs(Name = "gas_used")]
        public long GasUsed { get; protected set; }

        [DeserializeAs(Name = "nonce")]
        public long Nonce { get; protected set; }

        [DeserializeAs(Name = "confirmations")]
        public long Confirmations { get; protected set; }

        [DeserializeAs(Name = "input")]
        public string Input { get; protected set; }

        #region IEquatable<EthTransactionInfo>

        public bool Equals(EthTransactionInfo other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Chain, other.Chain) && TokenTransfers.SequenceEqual(other.TokenTransfers)
                && string.Equals(Status, other.Status) && Index == other.Index
                && string.Equals(TransactionHash, other.TransactionHash) && Value.Equals(other.Value)
                && string.Equals(FromAddress, other.FromAddress) && string.Equals(ToAddress, other.ToAddress)
                && string.Equals(Date, other.Date) && string.Equals(BlockHash, other.BlockHash)
                && BlockNumber == other.BlockNumber && Gas == other.Gas && GasPrice == other.GasPrice
                && GasUsed == other.GasUsed && Nonce == other.Nonce && Confirmations == other.Confirmations
                && string.Equals(Input, other.Input);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == this.GetType() && Equals((EthTransactionInfo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Chain != null ? Chain.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TokenTransfers != null ? TokenTransfers.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Index;
                hashCode = (hashCode * 397) ^ (TransactionHash != null ? TransactionHash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
                hashCode = (hashCode * 397) ^ (FromAddress != null ? FromAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ToAddress != null ? ToAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Date != null ? Date.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BlockHash != null ? BlockHash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ BlockNumber.GetHashCode();
                hashCode = (hashCode * 397) ^ Gas.GetHashCode();
                hashCode = (hashCode * 397) ^ GasPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ GasUsed.GetHashCode();
                hashCode = (hashCode * 397) ^ Nonce.GetHashCode();
                hashCode = (hashCode * 397) ^ Confirmations.GetHashCode();
                hashCode = (hashCode * 397) ^ (Input != null ? Input.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<EthTransactionInfo>
    }

    public class TokenTransfers : IEquatable<TokenTransfers>
    {
        [DeserializeAs(Name = "from")]
        public string FromAddress { get; protected set; }

        [DeserializeAs(Name = "to")]
        public string ToAddress { get; protected set; }

        [DeserializeAs(Name = "tokenName")]
        public string TokenName { get; protected set; }

        [DeserializeAs(Name = "symbol")]
        public string Symbol { get; protected set; }

        [DeserializeAs(Name = "tokenType")]
        public string TokenType { get; protected set; }

        [DeserializeAs(Name = "tokenID")]
        public string TokenId { get; protected set; }

        [DeserializeAs(Name = "value")]
        public string Value { get; protected set; }

        #region IEquatable<TokenTransfers>

        public bool Equals(TokenTransfers other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(FromAddress, other.FromAddress) && string.Equals(ToAddress, other.ToAddress) &&
                string.Equals(TokenName, other.TokenName) && string.Equals(Symbol, other.Symbol) &&
                string.Equals(TokenType, other.TokenType) && string.Equals(TokenId, other.TokenId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((TokenTransfers)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FromAddress != null ? FromAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ToAddress != null ? ToAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TokenName != null ? TokenName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Symbol != null ? Symbol.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TokenType != null ? TokenType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TokenId != null ? TokenId.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<TokenTransfers>
    }
}