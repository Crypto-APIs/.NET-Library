using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Exchanges.Info
{
    [TestClass]
    public class AssetDetails : BaseTest
    {
        [TestMethod]
        public void AllCorrect_ShouldPass()
        {
            var asset = Features.Eth;

            var response = Manager.Exchanges.Info.AssetDetails(asset);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Asset, $"'{nameof(response.Asset)}' must not be null");
            Assert.AreEqual("Ethereum", response.Asset.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset of null was inappropriately allowed.")]
        public void NullAsset_Exception()
        {
            Asset asset = null;

            Manager.Exchanges.Info.AssetDetails(asset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Asset.Id of null was inappropriately allowed.")]
        public void NullAssetId_Exception()
        {
            var asset = new Asset();

            Manager.Exchanges.Info.AssetDetails(asset);
        }

        [TestMethod]
        public void UnexistingAsset_ErrorMessage()
        {
            var asset = Features.UnexistingAsset;

            var response = Manager.Exchanges.Info.AssetDetails(asset);

            AssertErrorMessage(response, "Asset not found");
            Assert.IsNull(response.Asset, $"'{nameof(response.Asset)}' must be null");
        }
    }
}