using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges
{
    [TestClass]
    public class Periods : BaseTest
    {
        [TestMethod]
        public void TestSimple()
        {
            var response = Manager.Exchanges.Periods();

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Periods);
            Assert.IsTrue(response.Periods.Any());
        }
    }
}