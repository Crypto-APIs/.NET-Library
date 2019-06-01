using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.DecodeTransaction
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTestTestSimple()
        {
            var response = Manager.Blockchains.Transaction.DecodeTransaction(Coin, Network, HexEncodedInfo);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Transaction.Hash));
        }

        [TestMethod]
        public void WrongHexEncodedInfo()
        {
            var hexEncodedInfo = "qwe";
            var response = Manager.Blockchains.Transaction.DecodeTransaction(Coin, Network, hexEncodedInfo);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Can not decode transaction", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A HexEncodedInfo was inappropriately allowed.")]
        public void TestNullHexEncodedInfo()
        {
            Manager.Blockchains.Transaction.DecodeTransaction(Coin, Network, hexEncodedInfo: null);
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
        protected abstract string HexEncodedInfo { get; }
    }
}