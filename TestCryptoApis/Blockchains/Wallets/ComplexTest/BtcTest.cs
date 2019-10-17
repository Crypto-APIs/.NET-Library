using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class BtcTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcTestNet;

        protected override List<string> Addresses => _addresses ?? (_addresses = new List<string>
        {
            "muvTWioSTbJWK2HSRGcKoTfT7yDGhgaKso",
            "mkU95cnEYqKRb7G9RiLTAP2AbFazUAj2pa"
        });

        protected override List<string> AddedAddresses => _addedAdresses ?? (_addedAdresses = new List<string>
        {
            "moFJ97hAus3aipsn2Zny9aDdkic1j5GZ69",
        });

        private List<string> _addresses;
        private List<string> _addedAdresses;
    }
}