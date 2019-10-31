using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Tokens.GetTokens
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseCollectionTestWithoutSkip
    {
        [Ignore]
        [TestMethod]
        public override void MainTest()
        {
        }

        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Token.GetTokens<GetEthTokensResponse>(NetworkCoin, Address);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Token.GetTokens<GetEthTokensResponse>(NetworkCoin, Address, limit: limit);
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var address = "1'23";
            var response = Manager.Blockchains.Token.GetTokens<GetEthTokensResponse>(NetworkCoin, address);

            AssertErrorMessage(response, $"{address} is not a valid Ethereum address");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.Token.GetTokens<GetEthTokensResponse>(NetworkCoin, address);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string Address { get; }
    }
}