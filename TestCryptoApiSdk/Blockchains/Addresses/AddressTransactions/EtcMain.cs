using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override string Address { get; } = "0x1c0fa194a9d3b44313dcd849f3c6be6ad270a0a4";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
    }
}