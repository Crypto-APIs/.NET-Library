using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.DecodeTransaction
{
    [TestClass]
    public class BchMain : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BchMainNet;


        protected override string HexEncodedInfo { get; } =
            "0100000001c5701a72bdeb6fe02e37d5822478b0c59916e777d1dc98b788576e170d55d1a6010000006b483045022100a93330021b1ebd1cc0ae797365b8ba8788128a0330e09deb9a6e9fa04d3f923702203f634e4797571a796ff1bff380c5c98ce038ecff8638109d67fcb6a743ec339c412102bbdf59ece62b6a1d39de3f41d5186846b865aeeb538d7142756150fdbf537cadffffffff0192d54307000000001976a914aaa2a872b9a6dd0d9004fe439cc16d0b8a534b4988ac00000000"
            ;
    }
}