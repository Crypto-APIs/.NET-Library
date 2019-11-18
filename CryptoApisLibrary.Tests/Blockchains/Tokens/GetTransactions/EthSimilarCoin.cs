using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.Tokens.GetTransactions
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void InvalidAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var address = "1'23";

            var response = Manager.Blockchains.Token.GetTransactions<GetEthTransactionsResponse>(networkCoin, address);

            AssertErrorMessage(response, $"{address} is not a valid Ethereum address");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            string address = null;

            Manager.Blockchains.Token.GetTransactions<GetEthTransactionsResponse>(networkCoin, address);
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.EthMainNet };
                yield return new object[] { NetworkCoin.EthRinkeby };
                yield return new object[] { NetworkCoin.EthRopsten };
            }
        }
    }
}