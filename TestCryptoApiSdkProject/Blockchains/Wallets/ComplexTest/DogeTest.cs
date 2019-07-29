using System.Collections.Generic;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class DogeTest : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Doge;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;

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