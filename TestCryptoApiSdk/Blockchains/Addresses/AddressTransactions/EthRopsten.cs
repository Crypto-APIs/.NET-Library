using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EthRopsten : BaseEthSimilarCoin
    {
        protected override string Address { get; } = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRopsten;
    }
}