using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransaction
{
    [TestClass]
    public class DashMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashMainNet;

        protected override Dictionary<string, double> InputAddressesDictionary => _inputAddresses ?? (_inputAddresses = new Dictionary<string, double>
        {
            { "XkQXcew87m5FoY7Zuwd81ixkoFPMbYeENo", 0.54},
            { "Xd1ytQyjB5YHcWKypkUfQjfXqcdrEHY6Cw", 1.00}
        });

        protected override Dictionary<string, double> OutputAddressesDictionary => _outputAddresses ?? (_outputAddresses = new Dictionary<string, double>
        {
            { "XviPbBbm64KJ6Zje8YKQdtj6AmJvFXP3MH", 1.54},
        });

        private Dictionary<string, double> _inputAddresses;
        private Dictionary<string, double> _outputAddresses;
    }
}