using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransaction
{
    [TestClass]
    public class DogeMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DogeMainNet;

        protected override Dictionary<string, double> InputAddressesDictionary => _inputAddresses ?? (_inputAddresses = new Dictionary<string, double>
        {
            { "D6mpUJucStypmumqPAXGTr5wTS2q1bPScn", 0.54},
            { "D6n45H31Yr91ZS1KuKGq2tt7uNqVNU3QxJ", 1.00}
        });

        protected override Dictionary<string, double> OutputAddressesDictionary => _outputAddresses ?? (_outputAddresses = new Dictionary<string, double>
        {
            { "DCUrdaVWg71kBqNSrYWHV4AnXgd7XDmHK1", 1.54},
        });

        private Dictionary<string, double> _inputAddresses;
        private Dictionary<string, double> _outputAddresses;
    }
}