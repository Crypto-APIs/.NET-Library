using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.EstimateTransactionGas
{
    //[Ignore] // todo: temporarily ignored
    [TestClass]
    public class EtcMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMainNet;
        protected override string FromAddress { get; } = "0x7857af2143cb06ddc1dab5d7844c9402e89717cb";
        protected override string ToAddress { get; } = "0xc595B20EEC3d35E8f993d79262669F3ADb6328f7";
        protected override double Value { get; } = 0.12;
        protected override string Data { get; } =
            "24224747A80F225FD841E7AB2806A2FDF78525B58C1BC1F5D5A5D3943B4214B6C350CE0D973CAD81BD7A6E57048A487939D7CD6373BF8C9F3ADB6328f7";
    }
}