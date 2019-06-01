using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Info.GetLatestBlock
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetLatestBlock(Coin, Network);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.HashInfo.Chainwork));
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }

        [TestMethod]
        public void EthMain()
        {
            var response = Manager.Blockchains.Info.GetLatestBlock(EthSimilarCoin.Eth, EthSimilarNetwork.Mainnet);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("ETH.mainnet", response.HashInfo.Chain);
        }

        [TestMethod]
        public void EthRinkeby()
        {
            var response = Manager.Blockchains.Info.GetLatestBlock(EthSimilarCoin.Eth, EthSimilarNetwork.Rinkeby);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("ETH.rinkeby", response.HashInfo.Chain);
        }

        [TestMethod]
        public void EthRopsten()
        {
            var response = Manager.Blockchains.Info.GetLatestBlock(EthSimilarCoin.Eth, EthSimilarNetwork.Ropsten);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("ETH.ropsten", response.HashInfo.Chain);
        }
    }
}