using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class LtcMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.LtcMainNet;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.LtcMainNet;
    }
}