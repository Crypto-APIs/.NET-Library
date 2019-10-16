using CryptoApisSdkLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestCryptoApiSdk
{
    internal class ResponseRequestLogger : IResponseRequestLogger
    {
        public ResponseRequestLogger(TestContext testContext)
        {
            _testContext = testContext;
        }

        public void RegisterRequest(IRestClient client, IRestRequest request)
        {
            _testContext.WriteLine(GetRequestAsString(client, request));
        }

        public void RegisterResponse(IRestResponse response)
        {
            _testContext.WriteLine(GetResponseAsString(response));
        }

        private string GetResponseAsString(IRestResponse response)
        {
            return response.Content;
        }

        private string GetRequestAsString(IRestClient client, IRestRequest request)
        {
            return $"{client.BaseUrl}{request.Resource}";
        }

        private readonly TestContext _testContext;
    }
}