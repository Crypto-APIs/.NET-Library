using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ImportAddressAsWallet
{
    [TestClass]
    public class BtcTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcTestNet;
        protected override string Address { get; } = Features.CorrectAddress.BtcTestNet;
    }
}