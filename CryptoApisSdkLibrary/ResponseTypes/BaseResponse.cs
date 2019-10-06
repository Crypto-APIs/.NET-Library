namespace CryptoApisSdkLibrary.ResponseTypes
{
    public abstract class BaseResponse
    {
        public string ErrorMessage { get; set; }
        public string ResponseAsString { get; set; }
        public string RequestAsString { get; set; }
    }
}