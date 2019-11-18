using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.CreateTransactionPassword
{
    //[Ignore] // todo: temporarily ignored
    [TestClass]
    public class EthRopsten : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRopsten;
        protected override string FromAddress { get; } = Features.CorrectAddress.EthRopsten;
        protected override string ToAddress { get; } = Features.CorrectAddress2.EthRopsten;
        protected override double Value { get; } = 0.12;
    }
}