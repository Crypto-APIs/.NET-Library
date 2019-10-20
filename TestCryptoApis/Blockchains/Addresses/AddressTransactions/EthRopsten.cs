using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EthRopsten : BaseEthSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.EthRopsten;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRopsten;
    }
}