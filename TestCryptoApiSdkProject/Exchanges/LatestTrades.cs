using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class LatestTrades : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.LatestTrades();
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.LatestTrades(skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.LatestTrades(limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.LatestTrades(skip, limit);
        }

        protected override bool IsPerhapsNotAnExactMatch { get; } = true;
    }
}