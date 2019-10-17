using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class BtcTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "n4VQ5YdHf7hLQ2gWQYYrcxoE5B7nWuDFNF";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcTestNet;
    }
}