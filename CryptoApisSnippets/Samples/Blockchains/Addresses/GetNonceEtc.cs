using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetNonceEtc()
    {
      var address = "0x1c0fa194a9d3b44313dcd849f3c6be6ad270a0a4";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetNonce<EthGetNonceResponse>(
        NetworkCoin.EtcMainNet, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetNonceEtc executed successfully, " +
          $"nonce is {response.Payload.Nonce} now"
        : $"GetNonceEtc error: {response.ErrorMessage}");
    }
  }
}