using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class GetEthTransactionsResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ResponsePayload> Transactions { get; protected set; } = new List<ResponsePayload>();

        protected override IEnumerable<object> GetItems => Transactions;

        public class ResponsePayload : IEquatable<ResponsePayload>
        {
            [DeserializeAs(Name = "txHash")]
            public string TransactionHash { get; protected set; }

            [DeserializeAs(Name = "date")]
            public string Date { get; protected set; }

            [DeserializeAs(Name = "from")]
            public string From { get; protected set; }

            [DeserializeAs(Name = "to")]
            public string To { get; protected set; }

            [DeserializeAs(Name = "value")]
            public string Value { get; protected set; }

            [DeserializeAs(Name = "symbol")]
            public string Symbol { get; protected set; }

            [DeserializeAs(Name = "name")]
            public string Name { get; protected set; }

            [DeserializeAs(Name = "type")]
            public string Type { get; protected set; }

            #region IEquatable<ResponsePayload>

            public bool Equals(ResponsePayload other)
            {
                if (ReferenceEquals(null, other))
                    return false;
                if (ReferenceEquals(this, other))
                    return true;
                return TransactionHash == other.TransactionHash && Date == other.Date
                    && From == other.From && To == other.To && Value == other.Value
                    && Symbol == other.Symbol && Name == other.Name && Type == other.Type;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                return obj.GetType() == GetType() && Equals((ResponsePayload)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (TransactionHash != null ? TransactionHash.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Date != null ? Date.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (From != null ? From.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (To != null ? To.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Symbol != null ? Symbol.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                    return hashCode;
                }
            }

            #endregion IEquatable<ResponsePayload>
        }
    }
}