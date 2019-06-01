using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class GetExchanges : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.GetExchanges();
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.GetExchanges(skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.GetExchanges(limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.GetExchanges(skip, limit);
        }
    }
}