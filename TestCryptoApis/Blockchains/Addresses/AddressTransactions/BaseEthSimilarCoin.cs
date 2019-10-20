using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetEthAddressTransactionsResponse>(
                NetworkCoin, Address);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetEthAddressTransactionsResponse>(
                NetworkCoin, Address, skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetEthAddressTransactionsResponse>(
                NetworkCoin, Address, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Address.GetAddressTransactions<GetEthAddressTransactionsResponse>(
                NetworkCoin, Address, skip, limit);
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var address = "qw'e";
            var response = Manager.Blockchains.Address.GetAddressTransactions<GetEthAddressTransactionsResponse>(
                NetworkCoin, address);

            AssertErrorMessage(response, $"{address}  is not a valid Ethereum address");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.Address.GetAddressTransactions<GetEthAddressTransactionsResponse>(
                NetworkCoin, address);
        }

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        protected abstract string Address { get; }
        protected abstract NetworkCoin NetworkCoin { get; }
    }
}