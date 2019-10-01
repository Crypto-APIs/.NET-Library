using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
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
            var response = Manager.Blockchains.Address.GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
                NetworkCoin, address);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Address is not valid", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void TestBtcNullAddress()
        {
            Manager.Blockchains.Address.GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
                NetworkCoin, null);
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Address.GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
                NetworkCoin, Address);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Address.GetAddressInMultisignatureAddresses<GetBtcMultisignatureAddressesResponse>(
                NetworkCoin, Address, limit: limit);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string Address { get; }
    }
}