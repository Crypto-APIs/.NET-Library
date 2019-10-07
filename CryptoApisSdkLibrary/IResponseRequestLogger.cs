using RestSharp;

namespace CryptoApisSdkLibrary
{
    public interface IResponseRequestLogger
    {
        void RegisterRequest(IRestClient client, IRestRequest request);

        void RegisterResponse(IRestResponse response);
    }
}