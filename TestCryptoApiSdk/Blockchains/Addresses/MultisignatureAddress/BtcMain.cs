using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "1DUb2YYbQA1jjaNYzVXLZ7ZioEhLXtbUru";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcMainNet;
    }
}