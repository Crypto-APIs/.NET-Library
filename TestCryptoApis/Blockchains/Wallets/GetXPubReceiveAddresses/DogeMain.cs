using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.GetXPubReceiveAddresses
{
    [TestClass]
    public class DogeMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DogeMainNet;
    }
}