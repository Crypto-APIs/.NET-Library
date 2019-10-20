using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class DashTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashTestNet;

        protected override List<string> Addresses => _addresses ?? (_addresses = new List<string>
        {
            "yereyozxENB9jbhqpbg1coE5c39ExqLSaG",
            "yM74nFFXXwMUYXEDhpdNP2PCL6vkdkFhkS",
            "yUMsTCzv9HFjpNwUqfcU2S8Tav54MSG75Z"
        });

        protected override List<string> AddedAddresses => _addedAdresses ?? (_addedAdresses = new List<string>
        {
            "yiLJt21E81n1bMsTRHd7U6LvYWBqJx1LSj",
            "ycdyfff7NShT8T9X2BSCyax2GeZYizGdmn",
        });

        private List<string> _addresses;
        private List<string> _addedAdresses;
    }
}