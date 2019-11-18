using RestSharp.Deserializers;
using System;

namespace CryptoApisLibrary.DataTypes
{
    public class Account : IEquatable<Account>
    {
        /// <summary>
        /// Default constructor need for serialization/deserialization.
        /// </summary>
        public Account()
        { }

        public Account(string id) : this()
        {
            Id = id;
        }

        /// <summary>
        /// Id of your account.
        /// </summary>
        [DeserializeAs(Name = "accountId")]
        public string Id { get; protected set; }

        /// <summary>
        /// Exchange id supported in Trading APIs.
        /// </summary>
        [DeserializeAs(Name = "exchangeId")]
        public string ExchangeId { get; protected set; }

        /// <summary>
        /// Your api key in the exchange, needed for validating calls to Private APIs.
        /// </summary>
        [DeserializeAs(Name = "exchangeApiKey")]
        public string ExchangeApiKey { get; protected set; }

        #region IEquatable<Account>

        public bool Equals(Account other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && ExchangeId == other.ExchangeId && ExchangeApiKey == other.ExchangeApiKey;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((Account)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ExchangeId != null ? ExchangeId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ExchangeApiKey != null ? ExchangeApiKey.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<Asset>
    }
}