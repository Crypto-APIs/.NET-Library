using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.Transactions.DecodeTransaction
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTestTestSimple()
        {
            var response = Manager.Blockchains.Transaction.DecodeTransaction<BtcDecodeTransactionResponse>(NetworkCoin, HexEncodedInfo);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Transaction.Hash));
        }

        [TestMethod]
        public void WrongHexEncodedInfo()
        {
            var hexEncodedInfo = "qwe";
            var response = Manager.Blockchains.Transaction.DecodeTransaction<BtcDecodeTransactionResponse>(NetworkCoin, hexEncodedInfo);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Can not decode transaction");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A HexEncodedInfo was inappropriately allowed.")]
        public void TestNullHexEncodedInfo()
        {
            Manager.Blockchains.Transaction.DecodeTransaction<BtcDecodeTransactionResponse>(NetworkCoin, hexEncodedInfo: null);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string HexEncodedInfo { get; }
    }
}