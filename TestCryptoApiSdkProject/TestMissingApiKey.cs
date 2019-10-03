using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdkProject
{
    [TestClass]
    public class TestMissingApiKey : BaseTest
    {
        protected override string LoadApiKey()
        {
            return "123";
        }

        [TestMethod]
        public void Test()
        {
            var response = Manager.Exchanges.Exchanges();
            Assert.IsTrue("Invalid or missing API key".Equals(response.ErrorMessage));
            Assert.IsNotNull(response.Exchanges);
            Assert.IsFalse(response.Exchanges.Any());
        }
    }
}