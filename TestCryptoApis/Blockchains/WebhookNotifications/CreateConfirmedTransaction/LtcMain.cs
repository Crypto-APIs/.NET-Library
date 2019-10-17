﻿using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.WebhookNotifications.CreateConfirmedTransaction
{
    [TestClass]
    public class LtcMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.LtcMainNet;
        protected override string TransactionHash { get; } = "9bba7c4a8121f4bf9819ea481f4abd5e501db40815e23a70dfcb9e99eb9ba05e"; 
    }
}