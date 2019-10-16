using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHeight
{
    [TestClass]
    public class EthMorden : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
        protected override int BlockHeight { get; } = 1;
    }
}