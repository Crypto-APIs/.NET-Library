using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class BchMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BchMainNet;

        protected override List<string> Addresses => _addresses ?? (_addresses = new List<string>
        {
            "bitcoincash:qr3vzws2wwr3hdwhaxw9edrdscv7west45qel5yxj6",
            "bitcoincash:qphghkmf5zym4nwd45d5tagzzut3xpfkp52045tl2j",
            "bitcoincash:qr9pdsvzp9ylauqlrw7tys7px5rkf704hvr4t9xf0y"
        });

        protected override List<string> AddedAddresses => _addedAdresses ?? (_addedAdresses = new List<string>
        {
            "bitcoincash:qz2ug79qh070wxncr2r7vfr38y5dxh0qrcl4ljaql7",
            "bitcoincash:qqwpla38wq7vn8u04cjyngwajay2vlwh65h42z7993",
        });

        private List<string> _addresses;
        private List<string> _addedAdresses;
    }
}