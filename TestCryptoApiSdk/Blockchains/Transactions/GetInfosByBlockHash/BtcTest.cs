using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.GetInfosByBlockHash
{
    [TestClass]
    public class BtcTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcTestNet;
        protected override string BlockHash { get; } = "00000000000002d0eb6d0e13ef17baac65ce13159d7a91e7382285b600f2ccd2";
    }
}