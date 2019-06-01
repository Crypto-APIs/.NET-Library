using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class BtcMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "3DzSVk4veMCkNbNT9CdETeE26uWxmNbBnD";
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Btc;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Mainnet;
    }
}