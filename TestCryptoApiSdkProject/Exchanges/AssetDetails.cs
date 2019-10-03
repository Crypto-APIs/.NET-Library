using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class AssetDetails : BaseTest
    {
        [TestMethod]
        public void TestCorrect()
        {
            var asset = new Asset("5b755dacd5dd99000b3d92b2");
            var response = Manager.Exchanges.AssetDetails(asset);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Asset);
            Assert.AreEqual("Ethereum", response.Asset.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset of null was inappropriately allowed.")]
        public void TestNull()
        {
            Manager.Exchanges.AssetDetails(asset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.AssetDetails(new Asset());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var asset = new Asset("QWEE'WQ");
            var response = Manager.Exchanges.AssetDetails(asset);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Entity not found", response.ErrorMessage);
            Assert.IsNull(response.Asset);
        }
    }
}