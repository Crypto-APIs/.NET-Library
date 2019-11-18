using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.GetInfoByBlockHeightAndTransactionIndex
{
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
        protected override int BlockHeight { get; } = Features.CorrectBlockHeight.EtcMainNet;
        protected override int TransactionIndex { get; } = 2;
    }
}