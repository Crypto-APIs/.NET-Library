﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Address.GetAddressTransactions(Coin, Network, Address);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Blockchains.Address.GetAddressTransactions(Coin, Network, Address, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Address.GetAddressTransactions(Coin, Network, Address, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Blockchains.Address.GetAddressTransactions(Coin, Network, Address, skip, limit);
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var address = "qwe";
            var response = Manager.Blockchains.Address.GetAddressTransactions(
                Coin, Network, address);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"{address}  is not a valid Ethereum address", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            Manager.Blockchains.Address.GetAddress(Coin, Network, null);
        }

        protected abstract string Address { get; }
        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
    }
}