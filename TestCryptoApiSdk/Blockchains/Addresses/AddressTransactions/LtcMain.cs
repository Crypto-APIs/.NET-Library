using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class LtcMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "LL9nMSQrfp2RKwSdDZwHSDsyX44kTXqrKw";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.LtcMainNet;
    }
}