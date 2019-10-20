using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.EtcMainNet;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
    }
}