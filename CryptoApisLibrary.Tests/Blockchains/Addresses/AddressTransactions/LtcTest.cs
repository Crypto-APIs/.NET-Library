using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.LtcTestNet;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.LtcTestNet;
    }
}