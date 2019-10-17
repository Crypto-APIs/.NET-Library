namespace CryptoApisLibrary.ResponseTypes
{
    public interface IResponse
    {
        string ErrorMessage { get; }
        string ResponseAsString { get; set; }
    }
}