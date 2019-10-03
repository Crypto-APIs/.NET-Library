using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class ExchangeRatesTimeStamp : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, TimeStamp);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, TimeStamp, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, TimeStamp, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.ExchangeRates(BaseAsset, TimeStamp, skip, limit);
        }

        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130615");
        private DateTime TimeStamp { get; } = new DateTime(2019, 02, 03);
    }
}