using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class DogeTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.DogeTestNet;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DogeTestNet;
    }
}