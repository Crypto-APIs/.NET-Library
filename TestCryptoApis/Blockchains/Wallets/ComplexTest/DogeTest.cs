using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class DogeTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DogeTestNet;

        protected override List<string> Addresses => _addresses ?? (_addresses = new List<string>
        {
            "2MtyiFTv3aP9uWWeFZxz2hkJL7Dt5FY2LFV",
            "2NDutUPDhfMYGUFPhHRy4ZRraHVrEK7odr6",
            "2NE7KDFqtDFKavXH5YD7hvqU3ohZvzjmpva"
        });

        protected override List<string> AddedAddresses => _addedAdresses ?? (_addedAdresses = new List<string>
        {
            "ndtregJytQozES3eKkkSEjgFDDiXYvxR6t",
            "2My4aAqh43o6q27mEhp5TQLTcHYJN2n4wpC"
        });

        private List<string> _addresses;
        private List<string> _addedAdresses;
    }
}