using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class BchMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.BchMainNet;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BchMainNet;
    }
}