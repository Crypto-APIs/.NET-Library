using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdk.Exchanges.Ohlcv
{
    [TestClass]
    public class Periods : BaseTest
    {
        [TestMethod]
        public void TestSimple()
        {
            var response = Manager.Exchanges.Ohlcv.Periods();

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Periods, "Response.Periods must not be null");
            Assert.IsTrue(response.Periods.Any(), "Collection must not be empty");
        }
    }
}