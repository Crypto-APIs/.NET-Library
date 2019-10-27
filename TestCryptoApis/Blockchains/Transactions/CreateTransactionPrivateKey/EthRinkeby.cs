using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransactionPrivateKey
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRinkeby;
        protected override string FromAddress { get; } = Features.CorrectAddress.EthRinkenby;
        protected override string ToAddress { get; } = Features.CorrectAddress2.EthRinkenby;
        protected override double Value { get; } = 0.12;
    }
}