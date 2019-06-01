using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.ResponseTypes;
using CryptoApisSdkLibrary.ResponseTypes.Errors;
using RestSharp;

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

        private bool TryParseErrorMessage(IRestResponse response, out string errorMessage)
        {
            errorMessage = string.Empty;

            var responseObject1 = Client.Deserialize<ErrorResponseVariant1>(response);
            if (!string.IsNullOrEmpty(responseObject1.Data?.Message?.Message))
            {
                errorMessage = responseObject1.Data.Message.Message;
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

        protected readonly CryptoApiRequest Request;
        protected readonly IRestClient Client;
    }
}