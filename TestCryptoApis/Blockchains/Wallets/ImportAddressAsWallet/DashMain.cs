using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ImportAddressAsWallet
{
    [TestClass]
    public class DashMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashMainNet;
        protected override string Address { get; } = Features.CorrectAddress.DashMainNet;
    }
}