using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class BchTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.BchTestNet;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BchTestNet;
    }
}