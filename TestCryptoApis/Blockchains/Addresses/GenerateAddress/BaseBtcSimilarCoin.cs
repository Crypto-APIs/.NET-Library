using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.GenerateAddress
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var address = CheckGenerateAddress();

            var getAddressResponse = Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(NetworkCoin, address);

            AssertNullErrorMessage(getAddressResponse);
            Assert.IsFalse(string.IsNullOrEmpty(getAddressResponse.Payload.Address),
                $"'{nameof(getAddressResponse.Payload.Address)}' must not be null");
            Assert.AreEqual(address, getAddressResponse.Payload.Address, "'Address' is wrong");
        }

        protected virtual string CheckGenerateAddress()
        {
            var response = Manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(NetworkCoin);

            AssertNullErrorMessage(response);

            var address = response.Payload.Address;
            Assert.IsFalse(string.IsNullOrEmpty(address), $"'{nameof(address)}' must not be null");

            return address;
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}