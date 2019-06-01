using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.CreateTransactionPassword
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Rinkeby;
        protected override string FromAddress { get; } = ""; // todo: need corrected addresses
        protected override string ToAddress { get; } = "";
        protected override double Value { get; } = 0.12;
    }
}