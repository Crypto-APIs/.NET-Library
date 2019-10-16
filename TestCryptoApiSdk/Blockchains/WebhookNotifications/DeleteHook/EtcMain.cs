using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.WebhookNotifications.DeleteHook
{
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
    }
}