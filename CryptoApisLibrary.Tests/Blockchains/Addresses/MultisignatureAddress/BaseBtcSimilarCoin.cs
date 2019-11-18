using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseCollectionTestWithoutSkip
    {
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