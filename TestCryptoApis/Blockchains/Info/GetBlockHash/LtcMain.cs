using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class LtcMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.LtcMainNet;
        protected override string BlockHash { get; } = Features.CorrectBlockHash.LtcMainNet;
    }
}