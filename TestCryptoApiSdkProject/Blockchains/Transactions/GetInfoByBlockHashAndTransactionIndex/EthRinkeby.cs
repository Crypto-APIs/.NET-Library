﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfoByBlockHashAndTransactionIndex
{
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Rinkeby;
        protected override string BlockHash { get; } = "0x627e58320f6e59f2699f42737e6fda75d85f80f7e55ae524cc190537e6621b84";
        protected override int TransactionIndex { get; } = 1;
    }
}