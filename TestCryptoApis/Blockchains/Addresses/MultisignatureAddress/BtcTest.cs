using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class BtcTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.BtcTestNet;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcTestNet;
    }
}