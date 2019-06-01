using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfoByBlockHashAndTransactionIndex
{
    [TestClass]
    public class EthRopsten : BaseEthSimilarCoin
    {
        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Ropsten;
        protected override string BlockHash { get; } = "0x0114449f2f83df6947c12e91a9d44cf69cdb34eb1d4b169e373ed2ead785e568";
        protected override int TransactionIndex { get; } = 3;
    }
}