using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Tokens.TransferUsingPassword
{
    [TestClass]
    public class EtcMorden : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EtcMorden;
        protected override string FromAddress { get; } = "0xcbb36e2019f03c7d6dc8536b0d32e31aef18bded";
        protected override string ToAddress { get; } = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
        protected override string Contract { get; } = "0x3d045fcf9d7009450ca6c504ac164adba42dbbd3";
    }
}