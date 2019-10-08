using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Exchanges.Test
{
    [TestClass]
    public class AssetDetails : BaseTest
    {
        [TestMethod]
        public void TestCorrect()
        {
            var asset = new Asset("5b755dacd5dd99000b3d92b2!");
            var response = Manager.Exchanges.Info.AssetDetails(asset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Asset);
            Assert.AreEqual("Ethereum222", response.Asset.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An Asset of null was inappropriately allowed.")]
        public void TestNull()
        {
            Manager.Exchanges.Info.AssetDetails(asset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.Info.AssetDetails(new Asset());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var asset = new Asset("QWEE'WQ");
            var response = Manager.Exchanges.Info.AssetDetails(asset);

            AssertErrorMessage(response, "Entity not found");
            Assert.IsNull(response.Asset);
        }
    }
}