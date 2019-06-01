using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.CreateTransactionPrivateKeyWithGas
{
    [TestClass]
    public class EthRopsten : BaseEthSimilarCoin
    {
        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Ropsten;
        protected override string FromAddress { get; } = "0x7857af2143cb06ddc1dab5d7844c9402e89717cb";
        protected override string ToAddress { get; } = "0xc595B20EEC3d35E8f993d79262669F3ADb6328f7";
        protected override double Value { get; } = 0.12;
    }
}