using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfosByBlockHash
{
    [TestClass]
    public class BtcTest : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Btc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;
        protected override string BlockHash { get; } = "00000000000002d0eb6d0e13ef17baac65ce13159d7a91e7382285b600f2ccd2";
    }
}