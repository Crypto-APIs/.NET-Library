using System.Collections.Generic;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcMainNet;

        protected override List<string> Addresses => _addresses ?? (_addresses = new List<string>
        {
            "1MfyBywPTSj9aAPr8cccCTcch71fd4vkDA",
            "1B5WsYR8m4axbmEMMifveDL2gtZjtpaFr5",
            "1KRYkrh3dAkeBWPwxDZhrz9u8xf5NRK9UH"
        });

        protected override List<string> AddedAddresses => _addedAdresses ?? (_addedAdresses = new List<string>
        {
            "1Eeu3eC2b35LWtjXeRMJMSfrDnfDEjNwW6",
            "13ZiD6gSv75aNKdRyoUN39R3oSZEPML7er",
        });

        private List<string> _addresses;
        private List<string> _addedAdresses;
    }
}