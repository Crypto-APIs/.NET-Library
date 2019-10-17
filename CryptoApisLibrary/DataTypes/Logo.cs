using RestSharp.Deserializers;
using System;

namespace CryptoApisLibrary.DataTypes
{
    public class Logo : IEquatable<Logo>
    {
        /// <summary>
        /// MimeType.
        /// </summary>
        [DeserializeAs(Name = "mimeType")]
        public string MimeType { get; protected set; }

        /// <summary>
        /// Image data.
        /// </summary>
        [DeserializeAs(Name = "imageData")]
        public string ImageData { get; protected set; }

        #region IEquatable<Logo>

        public bool Equals(Logo other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return MimeType == other.MimeType && ImageData == other.ImageData;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((Logo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((MimeType != null ? MimeType.GetHashCode() : 0) * 397) ^ (ImageData != null ? ImageData.GetHashCode() : 0);
            }
        }

        #endregion IEquatable<Logo>
    }
}