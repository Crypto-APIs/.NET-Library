using System.Collections.Generic;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class DashTest : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Dash;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;

        protected override List<string> Addresses => _addresses ?? (_addresses = new List<string>
        {
            "bchtest:qpfpec7klx2x2mfn65n873jqcas395y9jcfl64ed4x",
            "bchtest:qq686unm4724lfjh09p4n30n3k649yj56uvyf54ste",
            "bchtest:qpfgn0raa4ehdnekslj728qhmetdf9cndctn4jp788"
        });

        protected override List<string> AddedAddresses => _addedAdresses ?? (_addedAdresses = new List<string>
        {
            "bchtest:qqmd9unmhkpx4pkmr6fkrr8rm6y77vckjvqe8aey35",
            "bchtest:pz6fgcu3jcu89ewt90swx9td4h6snauedsv3ca383a",
        });

        private List<string> _addresses;
        private List<string> _addedAdresses;
    }
}