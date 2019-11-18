using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Exchanges.Ohlcv
{
    [TestClass]
    public class Periods : BaseTest
    {
        [TestMethod]
        public void AllCorrect_ShouldPass()
        {
            var response = Manager.Exchanges.Ohlcv.Periods();

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Periods, $"{nameof(response.Periods)} must not be null");
            AssertNotEmptyCollection(nameof(response.Periods), response.Periods);
        }
    }
}