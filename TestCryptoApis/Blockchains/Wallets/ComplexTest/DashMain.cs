using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class DashMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashMainNet;

        protected override List<string> Addresses => _addresses ?? (_addresses = new List<string>
        {
            "XkQXcew87m5FoY7Zuwd81ixkoFPMbYeENo",
            "Xd1ytQyjB5YHcWKypkUfQjfXqcdrEHY6Cw",
            "XviPbBbm64KJ6Zje8YKQdtj6AmJvFXP3MH"
        });

        protected override List<string> AddedAddresses => _addedAdresses ?? (_addedAdresses = new List<string>
        {
            "XkbbwAD51RGDMJRE7mDBnyfSQzc6pUL9tS",
            "Xw7N8K91o2TDDpvJf3eg7mTH72c5NBTrtm",
        });

        private List<string> _addresses;
        private List<string> _addedAdresses;
    }
}