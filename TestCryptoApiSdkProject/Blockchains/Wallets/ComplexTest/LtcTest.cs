using System.Collections.Generic;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Ltc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;

        protected override List<string> Addresses => _addresses ?? (_addresses = new List<string>
        {
            "n2ov2TJfLv3vPdU7xZuycpwaJCxtwf2QTJ",
            "mkY9bvNEiLZCWwhpGiQ3mCBcNXd1DXzE8m"
        });

        protected override List<string> AddedAddresses => _addedAdresses ?? (_addedAdresses = new List<string>
        {
            "n336dnAvnm1evmVRZ1XHKkSfU8SiC11deq"
        });

        private List<string> _addresses;
        private List<string> _addedAdresses;
    }
}