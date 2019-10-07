using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class LtcMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "LKyKfVg4QDSyyraNPhWmVNThbXBfjSaikY";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.LtcMainNet;
    }
}