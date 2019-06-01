using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Info.GetInfo
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        //[Ignore] // todo: unknown error
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetInfo(Coin, Network);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsTrue(Coin.ToString().Equals(response.Info.Currency, StringComparison.OrdinalIgnoreCase));
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
    }
}