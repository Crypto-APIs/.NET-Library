using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class GetLatestQuoteTrades : BaseCollectionTestWithoutSkip
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.GetLatestQuoteTrades();
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.GetLatestQuoteTrades(limit: limit);
        }
    }
}