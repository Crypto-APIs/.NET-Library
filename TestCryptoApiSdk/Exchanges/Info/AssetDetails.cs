using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Exchanges.Info
{
    [TestClass]
    public class AssetDetails : BaseTest
    {
        [TestMethod]
        public void TestCorrect()
        {
            var asset = Features.Eth;
            var response = Manager.Exchanges.Info.AssetDetails(asset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Asset, $"'{nameof(response.Asset)}' must not be null");
            Assert.AreEqual("Ethereum", response.Asset.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void TestNull()
        {
            Asset asset = null;
            Manager.Exchanges.Info.AssetDetails(asset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            var asset = new Asset();
            Manager.Exchanges.Info.AssetDetails(asset);
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var asset = Features.UnexistingAsset;
            var response = Manager.Exchanges.Info.AssetDetails(asset);

            AssertErrorMessage(response, "Asset not found");
            Assert.IsNull(response.Asset, $"'{nameof(response.Asset)}' must be null");
        }
    }
}