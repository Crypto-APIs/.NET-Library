using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.WebhookNotifications.CreateConfirmedTransaction
{
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
        protected override string TransactionHash { get; } = "0x58576e8e1516697a071b180c7076b4e8906c61620d8916a02b0d5e707cb0f644";
    }
}