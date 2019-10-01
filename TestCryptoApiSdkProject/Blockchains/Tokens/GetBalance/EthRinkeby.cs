using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Tokens.GetBalance
{
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRinkeby;
        protected override string Address { get; } = "0x7857af2143cb06ddc1dab5d7844c9402e89717cb";
        protected override string Contract { get; } = "0x40f9405587B284f737Ef5c4c2ecEA1Fa8bfAE014";
    }
}