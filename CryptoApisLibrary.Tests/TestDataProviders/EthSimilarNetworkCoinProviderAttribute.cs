using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace CryptoApisLibrary.Tests.TestDataProviders
{
    public class EthSimilarNetworkCoinProviderAttribute : Attribute, ITestDataSource

    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { NetworkCoin.EthMainNet };
            yield return new object[] { NetworkCoin.EthRinkeby };
            yield return new object[] { NetworkCoin.EthRopsten };
            yield return new object[] { NetworkCoin.EtcMainNet };
            yield return new object[] { NetworkCoin.EtcMorden };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
}