using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.PushTransaction
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [Ignore] // todo: set corrected "HexEncodedInfo" value
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.PushTransaction(Coin, Network, HexEncodedInfo);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex));
        }

        [TestMethod]
        public void WrongHexEncodedInfo()
        {
            var hexEncodedInfo = "qwe";
            var response = Manager.Blockchains.Transaction.PushTransaction(Coin, Network, hexEncodedInfo);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("invalid argument 0: json: cannot unmarshal hex string without 0x prefix into Go value of type hexutil.Bytes", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongHexEncodedInfo2()
        {
            var hexEncodedInfo = "0xqwe";
            var response = Manager.Blockchains.Transaction.PushTransaction(Coin, Network, hexEncodedInfo);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("invalid argument 0: json: cannot unmarshal hex string of odd length into Go value of type hexutil.Bytes", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongHexEncodedInfo3()
        {
            var hexEncodedInfo = "0xqwer";
            var response = Manager.Blockchains.Transaction.PushTransaction(Coin, Network, hexEncodedInfo);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("invalid argument 0: json: cannot unmarshal invalid hex string into Go value of type hexutil.Bytes", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A HexEncodedInfo was inappropriately allowed.")]
        public void NullHexEncodedInfo()
        {
            Manager.Blockchains.Transaction.PushTransaction(Coin, Network, hexEncodedInfo: null);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        protected abstract string HexEncodedInfo { get; }
    }
}