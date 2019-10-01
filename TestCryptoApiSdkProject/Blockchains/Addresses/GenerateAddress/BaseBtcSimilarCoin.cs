using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.GenerateAddress
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(NetworkCoin);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            var address = response.Payload.Bch ?? response.Payload.Address;
            Assert.IsFalse(string.IsNullOrEmpty(address));

            var getAddressResponse = Manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(NetworkCoin, address);

            Assert.IsNotNull(getAddressResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getAddressResponse.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(getAddressResponse.Payload.Address));
            Assert.AreEqual(address, getAddressResponse.Payload.Address);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}