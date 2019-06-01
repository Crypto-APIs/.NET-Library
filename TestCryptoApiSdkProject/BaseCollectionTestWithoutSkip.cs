using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCryptoApiSdkProject
{
    [TestClass]
    public abstract class BaseCollectionTestWithoutSkip : BaseTest
    {
        [TestMethod]
        public virtual void MainTest()
        {
            AssertAllItems();
            AssertLimit();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Limit was inappropriately allowed.")]
        public void LimitIsNegative()
        {
            GetLimitList(0);
        }

        private void AssertAllItems()
        {
            Assert.IsNotNull(AllList);

            if (IsNeedAdditionalPackagePlan && IsAdditionalPackagePlan || !IsNeedAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(AllList.ErrorMessage));
                CheckMeta(AllList.Meta, DefaultLimit);

                Assert.IsNotNull(AllList.Items);
                if (AllList.Meta.Results > 0)
                {
                    Assert.IsTrue(AllList.Items.Any());
                }
                else
                {
                    Assert.IsFalse(AllList.Items.Any());
                }
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(AllList.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    AllList.ErrorMessage);
            }
        }

        private void AssertLimit()
        {
            if (Limit == null)
                return;

            Assert.IsNotNull(LimitList);

            if (IsNeedAdditionalPackagePlan && IsAdditionalPackagePlan || !IsNeedAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(LimitList.ErrorMessage));
                CheckLimit(AllList.Items, LimitList.Items, LimitList.Meta, Limit.Value);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(LimitList.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    LimitList.ErrorMessage);
            }
        }

        protected static void CheckMeta(MetaCollection meta, int limit)
        {
            Assert.IsNotNull(meta);
            Assert.AreEqual(limit, meta.Limit);
        }

        protected abstract ICollectionResponse GetAllList();

        protected abstract ICollectionResponse GetLimitList(int limit);

        protected ICollectionResponse AllList => _allList ?? (_allList = GetAllList());
        private ICollectionResponse _allList;

        protected ICollectionResponse LimitList => _limitList ?? (_limitList = GetLimitList(Limit.Value));
        private ICollectionResponse _limitList;

        protected void CheckLimit<T>(IEnumerable<T> allList, IEnumerable<T> actualList,
            MetaCollection meta, int limit)
        {
            Assert.IsNotNull(actualList);
            CheckMeta(meta, limit);

            if (IsPerhapsNotAnExactMatch)
                return;

            var all = allList as IList<T> ?? allList.ToList();
            var actual = actualList as IList<T> ?? actualList.ToList();

            Assert.AreEqual(Math.Min(all.Count, limit), actual.Count);

            for (var i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(all[i], actual[i]);
            }
        }

        protected static int? GetLimit<T>(IEnumerable<T> allList)
        {
            var enumerable = allList as IList<T> ?? allList.ToList();

            if (enumerable.Count > 2)
                return 2;
            if (enumerable.Count == 2)
                return 1;
            return null;
        }

        protected int? Limit => GetLimit(AllList.Items);

        protected const int DefaultLimit = 50;
        protected virtual bool IsNeedAdditionalPackagePlan { get; } = false;

        /// <summary>
        /// В некоторых тестах данные настолько динамично меняются, что к следующему запросу параметр "Skip" действует уже на другой
        /// "полный" список. Для таких тестов проверить адекватно работу "Skip", "Limit" невозможно.
        /// Эти тесты возводят этот флаг "Возможно не точное соответствие" в True.
        /// </summary>
        protected virtual bool IsPerhapsNotAnExactMatch { get; } = false;
    }
}