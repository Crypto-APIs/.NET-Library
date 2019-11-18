using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace CryptoApisLibrary.Tests.TestDataProviders
{
    public class BtcSimilarNetworkCoinProviderAttribute : Attribute, ITestDataSource

    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { NetworkCoin.BchMainNet };
            yield return new object[] { NetworkCoin.BchTestNet };
            yield return new object[] { NetworkCoin.BtcMainNet };
            yield return new object[] { NetworkCoin.BtcTestNet };
            yield return new object[] { NetworkCoin.DashMainNet };
            yield return new object[] { NetworkCoin.DashTestNet };
            yield return new object[] { NetworkCoin.DogeMainNet };
            yield return new object[] { NetworkCoin.DogeTestNet };
            yield return new object[] { NetworkCoin.LtcMainNet };
            yield return new object[] { NetworkCoin.LtcTestNet };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
}