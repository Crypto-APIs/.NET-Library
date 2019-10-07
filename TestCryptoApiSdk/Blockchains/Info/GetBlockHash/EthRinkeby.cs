using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRinkeby;
        protected override string BlockHash { get; } = "0x93a4dd08d2f8bfb2f502f9cace4b75f6380f7f283bf3ae62de357c1dceeaec14";
    }
}