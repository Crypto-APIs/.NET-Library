﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Tokens.GetTokens
{
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        [TestMethod]
        public override void MainTest()
        {
            
        }

        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Mainnet;
        protected override string Address { get; } = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
    }
}