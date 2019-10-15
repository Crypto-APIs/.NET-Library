using System.Diagnostics;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.ResponseTypes;
using CryptoApisSdkLibrary.ResponseTypes.Errors;
using RestSharp;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules
{
    internal class BaseModule
    {
        protected BaseModule(IRestClient client, CryptoApiRequest request)
        {
            Client = client;
            Request = request;
        }

        protected T MakeErrorMessage<T>(IRestResponse response) where T : BaseResponse, new()
        {
            string errorMessage;
            return new T
            {
                ErrorMessage = TryParseErrorMessage(response, out errorMessage)
                    ? errorMessage
                    : $"{nameof(T)} undefined error"
            };
        }

        /*protected T GetSync<T>(IRestRequest request) where T : BaseResponse, new()
        {
            var response = Client.Execute<T>(request);
            return response.IsSuccessful
                ? response.Data
                : MakeErrorMessage<T>(response);
        }*/

        protected Task<T> GetAsyncResponse<T>(IRestRequest request, CancellationToken cancellationToken)
            where T : BaseResponse, new()
        {
            return Task.Run(async () =>
            {
                _logger?.RegisterRequest(Client, request);

                 var response = await Client.ExecuteTaskAsync<T>(
                    request, cancellationToken);
                if (!response.IsSuccessful)
                    return MakeErrorMessage<T>(response);

                var result = response.Data;
                //result.RequestAsString = request.Resource;
                result.ResponseAsString = response.Content;

                _logger?.RegisterResponse(response);

                return result;
            }, cancellationToken);
        }

        private bool TryParseErrorMessage(IRestResponse response, out string errorMessage)
        {
            var responseObject1 = Client.Deserialize<ErrorResponseVariant1>(response);
            if (!string.IsNullOrEmpty(responseObject1.Data?.Meta?.Message))
            {
                errorMessage = responseObject1.Data.Meta.Message;
            }
            else
            {
                var responseObject2 = Client.Deserialize<ErrorResponseVariant2>(response);
                if (!string.IsNullOrEmpty(responseObject2.Data?.Meta?.Error?.Message))
                {
                    errorMessage = responseObject2.Data.Meta.Error.Message;
                }
                else
                {
                    var responseObject3 = Client.Deserialize<ErrorResponseVariant3>(response);
                    if (!string.IsNullOrEmpty(responseObject3.Data?.Error))
                    {
                        errorMessage = responseObject3.Data.Error;
                    }
                    else
                    {
                        errorMessage = !string.IsNullOrEmpty(response.ErrorMessage) ? response.ErrorMessage : response.StatusDescription;
                    }
                }
            }

            return !string.IsNullOrEmpty(errorMessage);
        }

        public void SetResponseRequestLogger(IResponseRequestLogger logger)
        {
            _logger = logger;
        }

        protected readonly CryptoApiRequest Request;
        protected readonly IRestClient Client;
        private IResponseRequestLogger _logger;
    }
}