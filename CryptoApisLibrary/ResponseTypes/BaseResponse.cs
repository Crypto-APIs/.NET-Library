namespace CryptoApisLibrary.ResponseTypes
{
    public abstract class BaseResponse : IResponse
    {
        public string ErrorMessage { get; set; }
        public string ResponseAsString { get; set; }
    }
}