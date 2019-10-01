using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdkProject.Blockchains.Info.GetInfo
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetInfo<GetBtcInfoResponse>(NetworkCoin);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsTrue(NetworkCoin.Coin.ToString().Equals(response.Info.Currency, StringComparison.OrdinalIgnoreCase));
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}