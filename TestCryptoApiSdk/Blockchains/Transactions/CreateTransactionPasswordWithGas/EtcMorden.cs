using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransactionPasswordWithGas
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
        protected override string FromAddress { get; } = "0x26588a9301b0428d95e6fc3a5024fce8bec12d51";
        protected override string ToAddress { get; } = "0x91c37bde81ddce4cef1f30528d3c6878e99af338";
        protected override double Value { get; } = 0.12;
    }
}