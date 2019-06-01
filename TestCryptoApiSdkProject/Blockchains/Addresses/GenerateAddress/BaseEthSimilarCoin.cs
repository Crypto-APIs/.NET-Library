using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.GenerateAddress
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Address.GenerateAddress(Coin, Network);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            var address = response.Payload.Address;
            Assert.IsFalse(string.IsNullOrEmpty(address));

            var getAddressResponse = Manager.Blockchains.Address.GetAddress(Coin, Network, address);

            Assert.IsNotNull(getAddressResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getAddressResponse.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(getAddressResponse.Payload.Address));
            Assert.AreEqual(address, getAddressResponse.Payload.Address);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
    }
}