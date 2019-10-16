using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Contracts.Deploy
{
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
        protected override string FromAddress { get; } = "0xe7cc96ba0562dfba61a55c8dd2e162a30942f402";

    }
}