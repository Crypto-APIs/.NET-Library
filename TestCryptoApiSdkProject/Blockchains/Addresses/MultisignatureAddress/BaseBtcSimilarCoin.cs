using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseCollectionTestWithoutSkip
    {
        [TestMethod]
        public void TestInvalidAddress()
        {
            var address = "qwe";
            var response = Manager.Blockchains.Address.GetAddressInMultisignatureAddresses(
                Coin, Network, address);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Address is not valid", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void TestBtcNullAddress()
        {
            Manager.Blockchains.Address.GetAddressInMultisignatureAddresses(
                Coin, Network, null);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Address.GetAddressInMultisignatureAddresses(
                Coin, Network, Address);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Address.GetAddressInMultisignatureAddresses(
                Coin, Network, Address, limit: limit);
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
        protected abstract string Address { get; }
    }
}