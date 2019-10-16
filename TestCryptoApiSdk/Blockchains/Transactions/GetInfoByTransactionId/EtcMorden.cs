using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.GetInfoByTransactionId
{
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;

        protected override string TransactionHash { get; } = "0x213ed2c788752539e24b56ebcc1dae932717f81e950fccfe485d61b26f3f27ab";
    }
}