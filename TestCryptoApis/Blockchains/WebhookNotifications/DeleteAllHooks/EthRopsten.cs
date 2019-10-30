using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.WebhookNotifications.DeleteAllHooks
{
    [TestClass]
    public class EthRopsten : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRopsten;
    }
}