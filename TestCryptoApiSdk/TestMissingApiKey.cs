using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdk
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
            var response = Manager.Exchanges.Info.Exchanges();
            AssertErrorMessage(response,"Invalid or missing API key");
            AssertEmptyCollection(nameof(response.Exchanges), response.Exchanges);
        }
    }
}