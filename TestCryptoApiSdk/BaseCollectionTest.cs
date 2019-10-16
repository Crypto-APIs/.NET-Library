using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCryptoApiSdk
{
    [TestClass]
    public abstract class BaseCollectionTest : BaseCollectionTestWithoutSkip
    {
        [TestMethod]
        public override void MainTest()
        {
            base.MainTest();

            AssertSkip();
            AssertSkipAndLimit();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Skip was inappropriately allowed.")]
        public void SkipIsNegative()
        {
            GetSkipList(-2);
        }

        [TestMethod]
        public virtual void SkipTooLarge()
        {
            var skip = 20000000;
            var response = GetSkipList(skip: skip);

            Assert.IsNotNull(response, $"'{nameof(response)}' must not be null");
            Assert.IsTrue(
                string.IsNullOrEmpty(response.ErrorMessage),
                $"'{nameof(response.ErrorMessage)}' must be null");
            AssertEmptyCollection(nameof(response.Items), response.Items);
        }

        private void AssertSkip()
        {
            if (Skip == null)
                return;

            Assert.IsNotNull(SkipList);

            if (IsNeedAdditionalPackagePlan && IsAdditionalPackagePlan || !IsNeedAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(SkipList.ErrorMessage), 
                    $"'{nameof(SkipList.ErrorMessage)}' must not be null");
                CheckSkip(AllList.Items, SkipList.Items, SkipList.Meta, Skip.Value, DefaultLimit);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(SkipList.ErrorMessage),
                    $"'{nameof(SkipList.ErrorMessage)}' must be null");
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    SkipList.ErrorMessage);
            }
        }

        private void AssertSkipAndLimit()
        {
            if (Skip == null || Limit == null)
                return;

            Assert.IsNotNull(SkipAndLimitList);

            if (IsNeedAdditionalPackagePlan && IsAdditionalPackagePlan || !IsNeedAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(SkipAndLimitList.ErrorMessage),
                    $"'{nameof(SkipAndLimitList.ErrorMessage)}' must not be null");
                CheckSkipAndLimit(AllList.Items, SkipAndLimitList.Items, SkipAndLimitList.Meta, Skip.Value, Limit.Value);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(SkipAndLimitList.ErrorMessage),
                    $"'{nameof(SkipAndLimitList.ErrorMessage)}' must be null");
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    SkipAndLimitList.ErrorMessage);
            }
        }

        protected static void CheckMeta(MetaCollection meta, int skip, int limit)
        {
            CheckMeta(meta, limit);

            Assert.AreEqual(skip, meta.Index, "'Skip' in 'meta' is wrong");
        }

        protected abstract ICollectionResponse GetSkipList(int skip);

        protected abstract ICollectionResponse GetSkipAndLimitList(int skip, int limit);

        protected ICollectionResponse SkipList => _skipList ?? (_skipList = GetSkipList(Skip.Value));
        private ICollectionResponse _skipList;

        protected ICollectionResponse SkipAndLimitList => _skipAndLimitList ?? (_skipAndLimitList = GetSkipAndLimitList(Skip.Value, Limit.Value));
        private ICollectionResponse _skipAndLimitList;

        protected void CheckSkip<T>(IEnumerable<T> allList, IEnumerable<T> actualList,
            MetaCollection meta, int skip, int defaultLimit)
        {
            Assert.IsNotNull(actualList);
            CheckMeta(meta, skip, defaultLimit);

            if (IsPerhapsNotAnExactMatch)
                return;

            var all = allList as IList<T> ?? allList.ToList();
            var actual = actualList as IList<T> ?? actualList.ToList();

            if (all.Count > skip)
            {
                Assert.IsTrue(actual.Any(), "Collection must not be empty");
            }

            for (var i = 0; i < all.Count - skip; i++)
            {
                Assert.AreEqual(all[i + skip], actual[i], "Skip failed");
            }
        }

        protected void CheckSkipAndLimit<T>(IEnumerable<T> allList, IEnumerable<T> actualList,
            MetaCollection meta, int skip, int limit)
        {
            Assert.IsNotNull(actualList);
            CheckMeta(meta, skip, limit);

            if (IsPerhapsNotAnExactMatch)
                return;

            var all = allList as IList<T> ?? allList.ToList();
            var actual = actualList as IList<T> ?? actualList.ToList();

            Assert.AreEqual(Math.Min(all.Count - skip, limit), actual.Count, "Skip and Limit count failed");

            for (var i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(all[i + skip], actual[i], $"Skip and Limit item not equal");
            }
        }

        protected static int? GetSkip<T>(IEnumerable<T> allList)
        {
            var enumerable = allList as IList<T> ?? allList.ToList();

            var skip = 0;
            if (enumerable.Count > 2)
                skip = 2;
            else if (enumerable.Count == 2)
                skip = 1;

            if (enumerable.Count <= skip)
                return null;

            return skip;
        }

        protected int? Skip => GetSkip(AllList.Items);
    }
}