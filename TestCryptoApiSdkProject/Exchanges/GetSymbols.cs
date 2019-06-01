using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class GetSymbols : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.GetSymbols();
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.GetSymbols(skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.GetSymbols(limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.GetSymbols(skip, limit);
        }
    }
}