using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.BtcMainNet;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcMainNet;
    }
}