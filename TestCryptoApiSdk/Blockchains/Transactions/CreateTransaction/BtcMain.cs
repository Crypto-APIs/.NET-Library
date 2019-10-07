using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestCryptoApiSdk.Blockchains.Transactions.CreateTransaction
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcMainNet;

        protected override Dictionary<string, double> InputAddressesDictionary => _inputAddresses ?? (_inputAddresses = new Dictionary<string, double>
        {
            { "1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9",0.54},
            { "1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q",1.00}
        });

        protected override Dictionary<string, double> OutputAddressesDictionary => _outputAddresses ?? (_outputAddresses = new Dictionary<string, double>
        {
            { "1EdcP2TSFsiQHNGvbbgsxgH7HfaFC54GwF", 1.54},
        });

        private Dictionary<string, double> _inputAddresses;
        private Dictionary<string, double> _outputAddresses;
    }
}