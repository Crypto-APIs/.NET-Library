using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.SendTransaction
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [Ignore] //  todo: set corrected "HexEncodedInfo" value
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.SendTransaction(Coin, Network, HexEncodedInfo);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Txid));
        }

        [TestMethod]
        public void WrongHexEncodedInfo()
        {
            var hexEncodedInfo = "qwe";
            var response = Manager.Blockchains.Transaction.SendTransaction(Coin, Network, hexEncodedInfo);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Can not send transaction: TX decode failed", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A HexEncodedInfo was inappropriately allowed.")]
        public void NullHexEncodedInfo()
        {
            Manager.Blockchains.Transaction.SendTransaction(Coin, Network, hexEncodedInfo: null);
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
        protected abstract string HexEncodedInfo { get; }
    }
}