using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfoByBlockHashAndTransactionIndex
{
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Mainnet;
        protected override string BlockHash { get; } = "0x0d13e81c01de31060a2830bb53761ef29ac5c4e5c1d43e309ca9a101140e394c";
        protected override int TransactionIndex { get; } = 79;
    }
}