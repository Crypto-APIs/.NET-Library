using System.Collections.Generic;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class LtcMain : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Ltc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;

        protected override List<string> Addresses => _addresses ?? (_addresses = new List<string>
        {
            "LdYmBLEYNHs4XDomUwCHAQi2RNZ61dvu9n",
            "LUc2pToUCLLGh3PdfMQonHQhFrQmFDwRwM",
            "Lad4PXW9HWQctdJVqcC97kSMzRw6iYRSjw",
            "LYXF1zZwXzMDWimEWzz4csoMaKfnwHMGxD"
        });

        protected override List<string> AddedAddresses => _addedAdresses ?? (_addedAdresses = new List<string>
        {
            "Lb9RWNxc5PUhN9Scs1j71ZceisBwDxXa1M",
            "LeEc6JDeaPoEJjAgxauq2SfZHw9TAsWGxD",
        });

        private List<string> _addresses;
        private List<string> _addedAdresses;
    }
}