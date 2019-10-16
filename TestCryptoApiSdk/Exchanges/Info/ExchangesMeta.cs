using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Exchanges.Info
{
    [TestClass]
    public class ExchangesMeta : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Info.ExchangesMeta();
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Info.ExchangesMeta(skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Info.ExchangesMeta(limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Info.ExchangesMeta(skip, limit);
        }
    }
}