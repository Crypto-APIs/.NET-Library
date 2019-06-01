using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.DecodeTransaction
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Btc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;
        protected override string HexEncodedInfo { get; } = 
            "02000000013f810859c03252a897dc1f5707ed9a3a5234ec4ef0ddafca9d933a0d32375380000000006a4730440220789cf627bc7e84e97dae9e94b97f6a790492511ad0be63afe424953846f9306a02206b99656cc96e58a717d5f47126b2ba49d612d9ef5ffb2d8b707d64d7629a776d0121023cf830a861754675344b72f0ef3654d5d47f156f7800cc6926b10309acf68899ffffffff011ced3200000000001976a914b20ecbedbb8c648e263487d40ab234cecefd34d588ac00000000";
    }
}