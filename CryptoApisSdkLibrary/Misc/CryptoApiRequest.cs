using RestSharp;
using System.Net;

namespace CryptoApisSdkLibrary.Misc
{
    public class CryptoApiRequest
    {
        private string MakeUri(string uri)
        {
            return $"{Consts.Version}/{uri}";
        }

        public ICredentials Credentials { get; set; }

        public IRestRequest Get(string url)
        {
            return new RestRequest(MakeUri(url), Method.GET) { Credentials = Credentials };
        }

        public IRestRequest Post(string url, object content = null)
        {
            var request = new RestRequest(MakeUri(url), Method.POST) { Credentials = Credentials }.AddJsonBody(content);
            request.JsonSerializer = new JsonSerializer();
            return request;
        }

        public IRestRequest Delete(string url)
        {
            return new RestRequest(MakeUri(url), Method.DELETE) { Credentials = Credentials };
        }
    }
}