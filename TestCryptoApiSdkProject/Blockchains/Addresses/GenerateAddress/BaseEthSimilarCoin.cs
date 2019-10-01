using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.GenerateAddress
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(NetworkCoin);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            var address = response.Payload.Address;
            Assert.IsFalse(string.IsNullOrEmpty(address));

            var getAddressResponse = Manager.Blockchains.Address.GetAddress<GetEthAddressResponse>(NetworkCoin, address);

            Assert.IsNotNull(getAddressResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getAddressResponse.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(getAddressResponse.Payload.Address));
            Assert.AreEqual(address, getAddressResponse.Payload.Address);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}