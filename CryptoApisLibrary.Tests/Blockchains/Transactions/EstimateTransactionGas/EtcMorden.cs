﻿using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.EstimateTransactionGas
{
    //[Ignore] // todo: temporarily ignored
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
        protected override string FromAddress { get; } = Features.CorrectAddress.EtcMorden;
        protected override string ToAddress { get; } = Features.CorrectAddress2.EtcMorden;
        protected override double Value { get; } = 0.12;
        protected override string Data { get; } =
            "24224747A80F225FD841E7AB2806A2FDF78525B58C1BC1F5D5A5D3943B4214B6C350CE0D973CAD81BD7A6E57048A487939D7CD6373BF8C9F3ADB6328f7";
    }
}