using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.GetXPubChangeAddresses
{
    [TestClass]
    public class DashMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashMainNet;
    }
}