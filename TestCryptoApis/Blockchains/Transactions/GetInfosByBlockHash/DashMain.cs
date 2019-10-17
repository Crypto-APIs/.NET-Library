using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.GetInfosByBlockHash
{
    [TestClass]
    public class DashMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashMainNet;
        protected override string BlockHash { get; } = "00000000000036312a44ab7711afa46f475913fbd9727cf508ed4af3bc933d16";
    }
}