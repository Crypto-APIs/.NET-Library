using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ImportAddressAsWallet
{
    [TestClass]
    public class BchMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BchMainNet;
        protected override string Address { get; } = Features.CorrectAddress.BchMainNet;
    }
}