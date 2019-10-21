using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetNonceEth()
    {
      var address = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetNonce<EthGetNonceResponse>(
        NetworkCoin.EthRopsten, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetNonceEth executed successfully, " +
          $"nonce is {response.Payload.Nonce} now"
        : $"GetNonceEth error: {response.ErrorMessage}");
    }
  }
}