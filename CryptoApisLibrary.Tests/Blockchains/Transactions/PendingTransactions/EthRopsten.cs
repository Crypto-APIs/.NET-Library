﻿using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.PendingTransactions
{
    [TestClass]
    public class EthRopsten : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthRopsten;
    }
}