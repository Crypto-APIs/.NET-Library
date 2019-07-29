using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfosByBlockHash
{
    [TestClass]
    public class DashMain : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Dash;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;
        protected override string BlockHash { get; } = "00000000000036312a44ab7711afa46f475913fbd9727cf508ed4af3bc933d16";
    }
}