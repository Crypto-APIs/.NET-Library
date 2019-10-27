using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransaction
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.LtcTestNet;

        protected override Dictionary<string, double> InputAddressesDictionary => _inputAddresses ?? (_inputAddresses = new Dictionary<string, double>
        {
            { "n2ov2TJfLv3vPdU7xZuycpwaJCxtwf2QTJ", 0.54},
            { "mkY9bvNEiLZCWwhpGiQ3mCBcNXd1DXzE8m", 1.00}
        });

        protected override Dictionary<string, double> OutputAddressesDictionary => _outputAddresses ?? (_outputAddresses = new Dictionary<string, double>
        {
            { "n336dnAvnm1evmVRZ1XHKkSfU8SiC11deq", 1.54},
        });

        private Dictionary<string, double> _inputAddresses;
        private Dictionary<string, double> _outputAddresses;
    }
}