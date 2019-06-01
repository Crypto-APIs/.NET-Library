using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class GetPeriods : BaseTest
    {
        [TestMethod]
        public void TestSimple()
        {
            var response = Manager.Exchanges.GetPeriods();

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Periods);
            Assert.IsTrue(response.Periods.Any());
        }
    }
}