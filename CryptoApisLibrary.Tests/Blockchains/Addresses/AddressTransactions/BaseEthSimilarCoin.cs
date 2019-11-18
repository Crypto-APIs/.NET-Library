using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.AddressTransactions
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

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        protected abstract string Address { get; }
        protected abstract NetworkCoin NetworkCoin { get; }
    }
}