using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, Address);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, Address, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, Address, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, Address, skip, limit);
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var address = "q'we";
            var response = Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, address);

            AssertErrorMessage(response, "Address is not valid");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
                NetworkCoin, address);
        }

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        protected abstract string Address { get; }
        protected abstract NetworkCoin NetworkCoin { get; }
    }
}