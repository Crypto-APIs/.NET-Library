using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Tokens.GetTokens
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseCollectionTestWithoutSkip
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Token.GetTokens<GetTokensResponse>(NetworkCoin, Address);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Token.GetTokens<GetTokensResponse>(NetworkCoin, Address, limit: limit);
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var address = "1'23";
            var response = Manager.Blockchains.Token.GetTokens<GetTokensResponse>(NetworkCoin, address);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, $"{address} is not a valid Ethereum address");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.Token.GetTokens<GetTokensResponse>(NetworkCoin, address);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string Address { get; }
    }
}