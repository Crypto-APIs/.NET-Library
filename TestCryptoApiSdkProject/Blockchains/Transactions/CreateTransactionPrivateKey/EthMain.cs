﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.CreateTransactionPrivateKey
{
    [Ignore] // todo: temporarily ignored
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Mainnet;
        protected override string FromAddress { get; } = "0xc438d912235ff5facc22c502e5bd6dc1ae14a7ff";
        protected override string ToAddress { get; } = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
        protected override double Value { get; } = 0.12;
    }
}