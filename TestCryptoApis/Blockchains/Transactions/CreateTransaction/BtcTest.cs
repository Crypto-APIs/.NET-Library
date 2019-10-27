using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransaction
{
    [TestClass]
    public class BtcTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcTestNet;

        protected override Dictionary<string, double> InputAddressesDictionary => _inputAddresses ?? (_inputAddresses = new Dictionary<string, double>
        {
            { "muvTWioSTbJWK2HSRGcKoTfT7yDGhgaKso", 0.54},
            { "mkU95cnEYqKRb7G9RiLTAP2AbFazUAj2pa", 1.00}
        });

        protected override Dictionary<string, double> OutputAddressesDictionary => _outputAddresses ?? (_outputAddresses = new Dictionary<string, double>
        {
            { "moFJ97hAus3aipsn2Zny9aDdkic1j5GZ69", 1.54},
        });

        private Dictionary<string, double> _inputAddresses;
        private Dictionary<string, double> _outputAddresses;
    }
}