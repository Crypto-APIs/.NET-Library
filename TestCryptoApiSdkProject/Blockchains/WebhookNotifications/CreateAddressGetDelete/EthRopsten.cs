﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.WebhookNotifications.CreateAddressGetDelete
{
    [TestClass]
    public class EthRopsten : BaseEthSimilarCoin
    {
        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Ropsten;
        protected override string Address { get; } = "0x37f3e1f7813b83015fdb6e8b6f928a77976e4691";
    }
}