using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Addresses.AddressTransactions
{
    [TestClass]
    public class DashMain : BaseBtcSimilarCoin
    {
        protected override string Address { get; } = "bitcoincash:qqu895wz2c07j0snr7auuyaqel09x28nrcwklyv03w";
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.DashMainNet;
    }
}