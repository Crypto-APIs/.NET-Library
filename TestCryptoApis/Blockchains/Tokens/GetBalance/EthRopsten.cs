using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Tokens.GetBalance
{
    [TestClass]
    public class EthRopsten : BaseEthSimilarCoin
    {
        [Ignore] // todo: no corrected adresses and contracts
        [TestMethod]
        public override void GeneralTest()
        { }

        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRopsten;
        protected override string Address { get; } = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
        protected override string Contract { get; } = "0xe7d553c3aab5943ec097d60535fd06f1b75db43e";
    }
}