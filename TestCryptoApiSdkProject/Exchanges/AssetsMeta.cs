using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class AssetsMeta : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.AssetsMeta();
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.AssetsMeta(skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.AssetsMeta(limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.AssetsMeta(skip, limit);
        }
    }
}