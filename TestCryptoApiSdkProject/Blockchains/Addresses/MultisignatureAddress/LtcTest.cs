using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.MultisignatureAddress
{
    [TestClass]
    public class LtcTest : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "mrkDpF1ZQTGwrbug8eCCHACYTPe2RQSJ3B";
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Ltc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;
    }
}