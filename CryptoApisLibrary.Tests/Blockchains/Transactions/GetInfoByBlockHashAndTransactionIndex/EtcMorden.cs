using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.GetInfoByBlockHashAndTransactionIndex
{
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
        protected override string BlockHash { get; } = Features.CorrectBlockHash.EtcMorden;
        protected override int TransactionIndex { get; } = 1;
    }
}