using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.DataTypes
{
    public class ExchangeSupportingAsset //: IEquatable<ExchangeSupportingAsset>
    {
        /// <summary>
        /// Unique exchange identification string (UID).
        /// </summary>
        [DeserializeAs(Name = "exchangeId")]
        public string ExchangeId { get; protected set; }

        /// <summary>
        /// Number of pairs in the exchange where asset is supported as base.
        /// </summary>
        [DeserializeAs(Name = "pairsAsBaseCount")]
        public int PairsAsBaseCount { get; protected set; }

        /// <summary>
        /// Number of pairs in the exchange where asset is supported as quote
        /// </summary>
        [DeserializeAs(Name = "pairsAsQuoteCount")]
        public int PairsAsQuoteCount { get; protected set; }

        public override string ToString()
        {
            return ExchangeId;
        }

        #region IEquatable<ExchangeSupportingAsset>

        // !!!!!!!!!!!!!!!!!!!!

        #endregion IEquatable<ExchangeSupportingAsset>
    }
}