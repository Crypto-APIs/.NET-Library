using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.GenerateAddress
{
    [TestClass]
    public abstract class BaseBchCoin : BaseBtcSimilarCoin
    {
        protected override string CheckGenerateAddress()
        {
            var response = Manager.Blockchains.Address.GenerateAddress<GenerateBchAddressResponse>(NetworkCoin);

            AssertNullErrorMessage(response);

            var address = response.Payload.Bch;
            Assert.IsFalse(string.IsNullOrEmpty(address), $"'{nameof(address)}' must not be null");

            return address;
        }
    }
}