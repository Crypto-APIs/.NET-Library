using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class DogeMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.DogeMainNet;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DogeMainNet;
    }
}