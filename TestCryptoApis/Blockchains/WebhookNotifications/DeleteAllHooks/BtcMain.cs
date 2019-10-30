using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.WebhookNotifications.DeleteAllHooks
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcMainNet;
    }
}