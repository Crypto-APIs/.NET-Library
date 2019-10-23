using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransactionPassword
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
        protected override string FromAddress { get; } = "0x2E00156fCF13Da534526E51f055E545d61c9191D";
        protected override string ToAddress { get; } = "0x1E95674d636a2D78D5BfAE646A4Abe4709F6F8Bd";
        protected override double Value { get; } = 0.12;
    }
}