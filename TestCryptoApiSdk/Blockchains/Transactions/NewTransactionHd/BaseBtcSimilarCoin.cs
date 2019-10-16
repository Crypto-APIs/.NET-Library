using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.Transactions.NewTransactionHd
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        protected override void BeforeTest()
        {
            Assert.AreEqual(2, InputAddresses.Count(), "'InputAddress' count is wrong");
            Assert.AreEqual(1, OutputAddresses.Count(), "'OutputAddress' count is wrong");
            Assert.AreEqual(InputAddresses.Sum(a => a.Value), OutputAddresses.Sum(a => a.Value),
                "Sum of 'inputAddresses' is not equal the sum of 'outputAddresses'");
        }

        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, InputAddresses, OutputAddresses, Fee);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Txid), "'Txid' must not be null");
        }

        [TestMethod]
        public void WrongInputsAddresses()
        {
            var inputAddresses = new List<TransactionAddress>
            {
                new TransactionAddress("q'we", 0.54),
            };
            var response = Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, inputAddresses, OutputAddresses, Fee);

            AssertErrorMessage(response, "Address is not valid");
        }

        [TestMethod]
        public void WrongOutputsAddresses()
        {
            var outputAddresses = new List<TransactionAddress>
            {
                new TransactionAddress("q'we", 0.54),
            };
            var response = Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, InputAddresses, outputAddresses, Fee);

            AssertErrorMessage(response, "Address is not valid");
        }

        [TestMethod]
        public void SendLessThanGet()
        {
            var output = OutputAddressesDictionary.First();
            var outputAddresses = new List<TransactionAddress>
            {
                new TransactionAddress(output.Key, output.Value * 10),
            };
            var response = Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, InputAddresses, outputAddresses, Fee);

            AssertErrorMessage(response, "Sum of input values is different then sum of output values");
        }

        [TestMethod]
        public void SendGreaterThanGet()
        {
            var output = OutputAddressesDictionary.First();
            var outputAddresses = new List<TransactionAddress>
            {
                new TransactionAddress(output.Key, output.Value / 10),
            };
            var response = Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, InputAddresses, outputAddresses, Fee);

            AssertErrorMessage(response, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An InputAddresses was inappropriately allowed.")]
        public void NullInputAddresses()
        {
            List<TransactionAddress> inputAddresses = null;
            Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, inputAddresses, OutputAddresses, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An OutputAddresses was inappropriately allowed.")]
        public void NullOutputAddresses()
        {
            List<TransactionAddress> outputAddresses = null;
            Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, InputAddresses, outputAddresses, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An InputAddresses was inappropriately allowed.")]
        public void EmptyInputAddresses()
        {
            var inputAddresses = new List<TransactionAddress>();
            Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, inputAddresses, OutputAddresses, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An OutputAddresses was inappropriately allowed.")]
        public void EmptyOutputAddresses()
        {
            var outputAddresses = new List<TransactionAddress>();
            Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, InputAddresses, outputAddresses, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Fee was inappropriately allowed.")]
        public void InvalidFee()
        {
            var fee = new Fee(-1);
            Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, InputAddresses, OutputAddresses, fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Wifs was inappropriately allowed.")]
        public void NullWifs()
        {
            IEnumerable<string> wifs = null;
            Manager.Blockchains.Transaction.NewTransaction<NewBtcTransactionResponse>(
                NetworkCoin, InputAddresses, OutputAddresses, Fee, wifs);
        }

        [TestMethod]
        public void FeeTooMuch()
        {
            var fee = new Fee(int.MaxValue);
            var response = Manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
                NetworkCoin, Wallet, Password, InputAddresses, OutputAddresses, fee);
            
            AssertErrorMessage(response, "todo: set corrected value");
        }

        private IEnumerable<TransactionAddress> GetTransactionAddresses(Dictionary<string, double> addresses)
        {
            return addresses.Select(address => new TransactionAddress(address.Key, address.Value));
        }

        private IEnumerable<TransactionAddress> InputAddresses =>
            _inputAddresses ?? (_inputAddresses = GetTransactionAddresses(InputAddressesDictionary));

        private IEnumerable<TransactionAddress> OutputAddresses =>
            _outputAddresses ?? (_outputAddresses = GetTransactionAddresses(OutputAddressesDictionary));

        private IEnumerable<TransactionAddress> _inputAddresses;
        private IEnumerable<TransactionAddress> _outputAddresses;

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract Dictionary<string, double> InputAddressesDictionary { get; }
        protected abstract Dictionary<string, double> OutputAddressesDictionary { get; }
        protected Fee Fee { get; } = new Fee(0.00001500);
        private string Wallet { get; } = "TestWallet";
        private string Password { get; } = "password";
    }
}