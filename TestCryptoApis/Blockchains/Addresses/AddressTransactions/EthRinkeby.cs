using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        protected override string Address { get; } = "0x54b7bc5bea3845198ff2936761087fc488504eed";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRinkeby;
    }
}