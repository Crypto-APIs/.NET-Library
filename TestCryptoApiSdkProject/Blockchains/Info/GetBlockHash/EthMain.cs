using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Info.GetBlockHash
{
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Mainnet;
        protected override string BlockHash { get; } = "0x79230d974f6cea8c11cc2f3a58c2b811313af17a2f7391de6665502910d4d383";
    }
}