using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.DecodeTransaction
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTestTestSimple()
        {
            var response = Manager.Blockchains.Transaction.DecodeTransaction<BtcDecodeTransactionResponse>(
                NetworkCoin, HexEncodedInfo);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Transaction.TransactionId),
                $"'{nameof(response.Transaction.TransactionId)}' must not be null");
        }

        [TestMethod]
        public void WrongHexEncodedInfo()
        {
            var hexEncodedInfo = "qw'e";
            var response = Manager.Blockchains.Transaction.DecodeTransaction<BtcDecodeTransactionResponse>(
                NetworkCoin, hexEncodedInfo);

            AssertErrorMessage(response, "Cannot decode transaction");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A HexEncodedInfo was inappropriately allowed.")]
        public void TestNullHexEncodedInfo()
        {
            string hexEncodedInfo = null;
            Manager.Blockchains.Transaction.DecodeTransaction<BtcDecodeTransactionResponse>(NetworkCoin, hexEncodedInfo);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string HexEncodedInfo { get; }
    }
}