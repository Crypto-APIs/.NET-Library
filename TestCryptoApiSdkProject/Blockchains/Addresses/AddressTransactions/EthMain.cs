using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        protected override string Address { get; } = "0xb794F5eA0ba39494cE839613fffBA74279579268";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthMainNet;
    }
}