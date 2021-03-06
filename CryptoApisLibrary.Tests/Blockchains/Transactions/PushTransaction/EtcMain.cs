﻿using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.PushTransaction
{
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
        protected override string HexEncodedInfo { get; } = ""; // todo: set corrected value

        [Ignore]
        [TestMethod]
        public override void WrongHexEncodedInfo()
        { }

        [Ignore]
        [TestMethod]
        public override void WrongHexEncodedInfo2()
        { }

        [Ignore]
        [TestMethod]
        public override void WrongHexEncodedInfo3()
        { }
    }
}