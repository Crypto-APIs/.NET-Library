using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.DataTypes
{
    public class Wallet
    {
        [DeserializeAs(Name = "addresses")]
        public List<string> Addresses { get; protected set; } = new List<string>();

        /// <remarks>
        /// Applied only for BCH
        /// </remarks>
        [DeserializeAs(Name = "legacy")]
        public List<string> LegacyAddresses { get; protected set; }

        [DeserializeAs(Name = "walletName")]
        public string Name { get; protected set; }
    }
}