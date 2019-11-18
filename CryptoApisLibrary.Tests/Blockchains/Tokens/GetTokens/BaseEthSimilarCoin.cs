using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Tokens.GetTokens
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

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string Address { get; }
    }
}