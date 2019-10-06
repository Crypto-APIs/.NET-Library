using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges.Trades
{
    [TestClass]
    public class HistoricalTradesByAssetPairAndExchange : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, QuoteAsset, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void TestNullBaseAsset()
        {
            Manager.Exchanges.Trades.Historical(Exchange, baseAsset: null, quoteAsset: QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Quote of null was inappropriately allowed.")]
        public void TestNullQuoteAsset()
        {
            Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, quoteAsset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Manager.Exchanges.Trades.Historical(exchange: null, baseAsset: BaseAsset, quoteAsset: QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void TestNullBaseAssetId()
        {
            Manager.Exchanges.Trades.Historical(Exchange, new Asset(), QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void TestNullQuoteAssetId()
        {
            Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, new Asset());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            Manager.Exchanges.Trades.Historical(new Exchange(), BaseAsset, QuoteAsset);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = new Asset("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Historical(Exchange, baseAsset, QuoteAsset);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.AreEqual("We are facing technical issues, please try again later", response.ErrorMessage);
                Assert.IsNotNull(response.Trades);
                Assert.IsFalse(response.Trades.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = new Asset("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Historical(Exchange, BaseAsset, quoteAsset);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.AreEqual("We are facing technical issues, please try again later", response.ErrorMessage);
                Assert.IsNotNull(response.Trades);
                Assert.IsFalse(response.Trades.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = new Exchange("QWE'EWQ1");
            var response = Manager.Exchanges.Trades.Historical(exchange, BaseAsset, QuoteAsset);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.AreEqual("We are facing technical issues, please try again later", response.ErrorMessage);
                Assert.IsNotNull(response.Trades);
                Assert.IsFalse(response.Trades.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        protected override bool IsNeedAdditionalPackagePlan { get; } = true;
        //protected override bool IsPerhapsNotAnExactMatch { get; } = true;

        private Exchange Exchange { get; } = new Exchange("5b1ea9d21090c200146f7362");
        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130612");
        private Asset QuoteAsset { get; } = new Asset("5b1ea92e584bf50020130615");
    }
}