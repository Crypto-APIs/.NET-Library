using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TestCryptoApiSdkProject.Exchanges
{
    [Ignore] // #012
    [TestClass]
    public class GetArbitrageInfo : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.GetArbitrageInfo();
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.GetArbitrageInfo(skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.GetArbitrageInfo(limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.GetArbitrageInfo(skip, limit);
        }
    }
}