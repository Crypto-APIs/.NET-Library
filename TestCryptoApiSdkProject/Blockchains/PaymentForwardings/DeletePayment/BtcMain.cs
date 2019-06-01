using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.PaymentForwardings.DeletePayment
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Btc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;
    }
}