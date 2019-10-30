using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ImportAddressAsWallet
{
    [TestClass]
    public class DashTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashTestNet;
        protected override string Address { get; } = Features.CorrectAddress.DashTestNet;
    }
}