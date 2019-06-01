﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Tokens.TransferUsingPassword
{
    [TestClass]
    public class EthRinkeby : BaseEthSimilarCoin
    {
        protected override EthSimilarCoin Coin { get; } = EthSimilarCoin.Eth;
        protected override EthSimilarNetwork Network { get; } = EthSimilarNetwork.Rinkeby;
        protected override string FromAddress { get; } = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
        protected override string ToAddress { get; } = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
        protected override string Contract { get; } = "0xe7d553c3aab5943ec097d60535fd06f1b75db43e";
    }
}