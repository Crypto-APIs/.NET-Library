using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.EtcMorden;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
    }
}