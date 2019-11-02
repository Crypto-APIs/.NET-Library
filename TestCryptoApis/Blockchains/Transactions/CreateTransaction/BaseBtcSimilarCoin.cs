using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCryptoApis.Blockchains.Transactions.CreateTransaction
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        protected override void BeforeTest()
        {
            Assert.AreEqual(2, InputAddresses.Count(), "'InputAddresses' count is wrong");
            Assert.AreEqual(1, OutputAddresses.Count(), "'OutputAddresses' count is wrong");
            Assert.AreEqual(InputAddresses.Sum(a => a.Value), OutputAddresses.Sum(a => a.Value),
                "Sum of 'inputAddresses' is not equals sum of 'outputAddresses'");
        }

        [Ignore]
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, InputAddresses, OutputAddresses, Fee);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex));
        }

        [TestMethod]
        public void NotEnoughBalance()
        {
            // increase in "multiplier" times
            var multiplier = 100000000;
            var inputAddresses = InputAddresses.Select(
                address => new TransactionAddress(address.Address, address.Value * multiplier));
            var outputAddresses = OutputAddresses.Select(
                address => new TransactionAddress(address.Address, address.Value * multiplier));

            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, inputAddresses, outputAddresses, Fee);
            AssertErrorMessagePart(response, "Not enough balance in ");
            Assert.IsTrue(response.Payload == null);
        }

        [TestMethod]
        public void WrongInputsAddresses()
        {
            var inputAddresses = new List<TransactionAddress>
            {
                new TransactionAddress("qw'e", 0.54),
            };
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, inputAddresses, OutputAddresses, Fee);

            AssertErrorMessage(response, "Address is not valid");
        }

        [TestMethod]
        public void WrongOutputsAddresses()
        {
            var outputAddresses = new List<TransactionAddress>
            {
                new TransactionAddress("q'we", 0.54),
            };
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, InputAddresses, outputAddresses, Fee);

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
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, InputAddresses, outputAddresses, Fee);

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
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, InputAddresses, outputAddresses, Fee);

            AssertErrorMessage(response, "Sum of input values is different then sum of output values");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An InputAddresses was inappropriately allowed.")]
        public void NullInputAddresses()
        {
            List<TransactionAddress> inputAddresses = null;
            Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, inputAddresses, OutputAddresses, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An OutputAddresses was inappropriately allowed.")]
        public void NullOutputAddresses()
        {
            List<TransactionAddress> outputAddresses = null;
            Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, InputAddresses, outputAddresses, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An InputAddresses was inappropriately allowed.")]
        public void EmptyInputAddresses()
        {
            var inputAddresses = new List<TransactionAddress>();
            Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, inputAddresses, OutputAddresses, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An OutputAddresses was inappropriately allowed.")]
        public void EmptyOutputAddresses()
        {
            var outputAddresses = new List<TransactionAddress>();
            Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, InputAddresses, outputAddresses, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Fee was inappropriately allowed.")]
        public void InvalidFee()
        {
            var fee = new Fee(-1);
            Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, InputAddresses, OutputAddresses, fee);
        }

        [TestMethod]
        public void FeeTooMuch()
        {
            var fee = new Fee(int.MaxValue);
            var response = Manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
                NetworkCoin, InputAddresses, OutputAddresses, fee);

            AssertErrorMessagePart(response,
                $"Not enough balance in '{InputAddressesDictionary.First().Key}' available ");
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
    }
}