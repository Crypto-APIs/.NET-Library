using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        protected override string Address { get; } = Features.CorrectAddress.EthRinkenby;
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRinkeby;
    }
}