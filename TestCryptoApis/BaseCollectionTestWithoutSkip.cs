using System;
using System.Collections.Generic;
using System.Linq;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis
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
            Assert.IsNotNull(AllList, $"'{nameof(AllList)}' must not be null");

            if (IsNeedAdditionalPackagePlan && IsAdditionalPackagePlan || !IsNeedAdditionalPackagePlan)
            {
                AssertNullErrorMessage(AllList);
                CheckMeta(AllList.Meta, DefaultLimit);

                if (AllList.Meta.Results > 0)
                {
                    Assert.IsNotNull(AllList.Items, $"'{nameof(AllList.Items)}' must not be null");
                    AssertNotEmptyCollection("AllList", AllList.Items);
                }
                else
                {
                    AssertEmptyCollection("AllList", AllList.Items);
                }
            }
            else
            {
                AssertErrorMessage(AllList,
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        private void AssertLimit()
        {
            if (Limit == null)
                return;

            Assert.IsNotNull(LimitList, $"'{nameof(LimitList)}' must not be null");

            if (IsNeedAdditionalPackagePlan && IsAdditionalPackagePlan || !IsNeedAdditionalPackagePlan)
            {
                AssertNullErrorMessage(LimitList);
                CheckLimit(AllList.Items, LimitList.Items, LimitList.Meta, Limit.Value);
            }
            else
            {
                AssertErrorMessage(LimitList, 
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        protected static void CheckMeta(MetaCollection meta, int limit)
        {
            Assert.IsNotNull(meta, $"'{nameof(meta)}' must not be null");
            Assert.AreEqual(limit, meta.Limit, $"'Limit' in meta is wrong");
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
            Assert.IsNotNull(actualList, $"'{nameof(actualList)}' must not be null");
            CheckMeta(meta, limit);

            var all = allList as IList<T> ?? allList.ToList();
            var actual = actualList as IList<T> ?? actualList.ToList();
            Assert.AreEqual(Math.Min(all.Count, limit), actual.Count, $"Limit count is wrong");

            if (IsPerhapsNotAnExactMatch)
            {
                //CheckCollectionNotAnExactMatch(all, actual, "Limit  (NotAnExactMatch mode) failed, items are not equal");
            }
            else
            {
                for (var i = 0; i < actual.Count; i++)
                {
                    Assert.AreEqual(all[i], actual[i], $"Limit failed, items are not equal");
                }
            }
            /*if (IsPerhapsNotAnExactMatch)
                return;

            var all = allList as IList<T> ?? allList.ToList();
            var actual = actualList as IList<T> ?? actualList.ToList();

            Assert.AreEqual(Math.Min(all.Count, limit), actual.Count, $"Limit count is wrong");

            for (var i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(all[i], actual[i], $"Limit failed, items are not equal");
            }*/
        }

        protected void CheckCollectionNotAnExactMatch<T>(IList<T> allList, IList<T> actualList, string errorMessage)
        {
            int? indexInActualList = null;
            var indexInAllListOfFirstItemInActualList = 0;
            for (var i = 0; i < actualList.Count; i++)
            {
                indexInAllListOfFirstItemInActualList = allList.IndexOf(actualList[i]);
                if (indexInAllListOfFirstItemInActualList != -1)
                {
                    indexInActualList = i;
                    break;
                }
            }

            if (indexInActualList == null)
                return;

            var j = 0;
            for (var i = indexInActualList.Value; i < actualList.Count; i++)
            {
                if (!allList[indexInAllListOfFirstItemInActualList + j].Equals(actualList[i]))
                {
                    Assert.Fail(errorMessage);
                }
                Assert.AreEqual(allList[indexInAllListOfFirstItemInActualList + j], actualList[i], 
                    $"{errorMessage}. ActualIndex={i}, AllIndex={indexInAllListOfFirstItemInActualList + j}");
                j++;
                if (indexInAllListOfFirstItemInActualList + j >= allList.Count)
                    break;
            }
        }

        protected static int? GetLimit<T>(IEnumerable<T> allList)
        {
            var enumerable = allList as IList<T> ?? allList.ToList();

            if (enumerable.Count > 20)
                return 20;
            if (enumerable.Count > 10)
                return 10;
            if (enumerable.Count > 5)
                return 5;
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