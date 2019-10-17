using RestSharp;

namespace CryptoApisLibrary
{
    public interface IResponseRequestLogger
    {
        void RegisterRequest(IRestClient client, IRestRequest request);

        void RegisterResponse(IRestResponse response);
    }
}