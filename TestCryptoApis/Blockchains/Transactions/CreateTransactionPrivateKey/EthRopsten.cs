using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransactionPrivateKey
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EthRopsten : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRopsten;
        protected override string FromAddress { get; } = "0x7857af2143cb06ddc1dab5d7844c9402e89717cb";
        protected override string ToAddress { get; } = "0xc595B20EEC3d35E8f993d79262669F3ADb6328f7";
        protected override double Value { get; } = 0.12;
    }
}