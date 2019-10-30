using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.WebhookNotifications.CreateTransactionConfirmations
{
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
        protected override string Address { get; } = Features.CorrectAddress.EtcMorden;
    }
}