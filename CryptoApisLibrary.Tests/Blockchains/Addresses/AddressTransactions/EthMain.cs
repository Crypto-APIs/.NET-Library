using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.EthMainNet;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthMainNet;
    }
}