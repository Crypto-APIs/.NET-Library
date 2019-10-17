using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.SendTransaction
{
    [TestClass]
    public class BtcTest : BaseBtcSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.BtcTestNet;

        protected override string HexEncodedInfo { get; } =
            "02000000012ef6ff4aaa76aaff4bea235df134923a830a89d2fbdea5fdc330c9a42eb920a8010000006a47304402205c44fb58b3eaa907cccb2cac87749f00cb52f0d050d183ebba80d672413b9a540220749c8b53665db9f36d5e760ad627b0e22072a6cf91a5d77d35ac2b95d4c1ea54012102275753690ab58df3c923001e94d407e30b03e60b1f2461729a1dd4f37ebe2469ffffffff02c8320000000000001976a914481e003d23566c1789dc9362085c3a0876570c7c88ac80380100000000001976a9147b9a627a184897f10d31d73d87c2eea191d8f50188ac00000000"
            ;
    }
}