using RestSharp.Deserializers;
using System;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class Exchange : ExchangeMeta, IEquatable<Exchange>
    {
        /// <summary>
        /// Default constructor need for serialization/deserialization.
        /// </summary>
        public Exchange()
        { }

        public Exchange(string id) : base(id)
        { }
        
        /// <summary>
        /// Exchange website address.
        /// </summary>
        [DeserializeAs(Name = "website")]
        public string Website { get; protected set; }

        /// <summary>
        /// Object holding meta information about exchange logo e.g. mime type, and base64 encoded image data, etc.
        /// </summary>
        [DeserializeAs(Name = "logo")]
        public Logo Logo { get; protected set; }

        #region IEquatable<Exchange>

        public bool Equals(Exchange other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return base.Equals(other) && string.Equals(Website, other.Website) && Equals(Logo, other.Logo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is Exchange && Equals((Exchange)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Website != null ? Website.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Logo != null ? Logo.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion IEquatable<Exchange>
    }
}