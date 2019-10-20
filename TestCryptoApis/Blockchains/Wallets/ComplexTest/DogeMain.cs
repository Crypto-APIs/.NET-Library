using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class DogeMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DogeMainNet;

        protected override List<string> Addresses => _addresses ?? (_addresses = new List<string>
        {
            "D6mpUJucStypmumqPAXGTr5wTS2q1bPScn",
            "D6n45H31Yr91ZS1KuKGq2tt7uNqVNU3QxJ",
            "DCUrdaVWg71kBqNSrYWHV4AnXgd7XDmHK1"
        });

        protected override List<string> AddedAddresses => _addedAdresses ?? (_addedAdresses = new List<string>
        {
            "D9AZp3rjNSCkHTx7fWpA8wFMa8jdr4Zi2J",
            "D8Naf5jn7M2sodNEvQHXfDQY6iF43xUCf4",
        });

        private List<string> _addresses;
        private List<string> _addedAdresses;
    }
}