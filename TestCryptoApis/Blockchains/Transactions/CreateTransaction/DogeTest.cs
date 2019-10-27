using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransaction
{
    [TestClass]
    public class DogeTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DogeTestNet;

        protected override Dictionary<string, double> InputAddressesDictionary => _inputAddresses ?? (_inputAddresses = new Dictionary<string, double>
        {
            { "2MtyiFTv3aP9uWWeFZxz2hkJL7Dt5FY2LFV", 0.54},
            { "2NDutUPDhfMYGUFPhHRy4ZRraHVrEK7odr6", 1.00}
        });

        protected override Dictionary<string, double> OutputAddressesDictionary => _outputAddresses ?? (_outputAddresses = new Dictionary<string, double>
        {
            { "2NE7KDFqtDFKavXH5YD7hvqU3ohZvzjmpva", 1.54},
        });

        private Dictionary<string, double> _inputAddresses;
        private Dictionary<string, double> _outputAddresses;
    }
}