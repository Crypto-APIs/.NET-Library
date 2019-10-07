using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "3DzSVk4veMCkNbNT9CdETeE26uWxmNbBnD";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcMainNet;
    }
}