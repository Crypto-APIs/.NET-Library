using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcMainNet;
        protected override string BlockHash { get; } = "00000000000000000013dc04902f71e2a4b16d45497eb189beb805e57c5ce1e4";
    }
}