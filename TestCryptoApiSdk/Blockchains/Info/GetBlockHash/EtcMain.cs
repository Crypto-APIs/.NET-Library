using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
        protected override string BlockHash { get; } = "0x3b41239a11d264e14786d48f3719a4ceee7b5a711f821df312a056ec4e755e88";
    }
}