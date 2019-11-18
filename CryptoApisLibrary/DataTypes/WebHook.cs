using RestSharp.Deserializers;
using System;

namespace CryptoApisLibrary.DataTypes
{
    public class WebHook : IEquatable<WebHook>
    {
        [DeserializeAs(Name = "uuid")]
        public string Id { get; protected set; }

        [DeserializeAs(Name = "event")]
        public string Event { get; protected set; }

        [DeserializeAs(Name = "url")]
        public string Url { get; protected set; }

        #region IEquatable<WebHook>

        public bool Equals(WebHook other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && Event == other.Event && Url == other.Url;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((WebHook)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Event != null ? Event.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Url != null ? Url.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<WebHook>
    }
}