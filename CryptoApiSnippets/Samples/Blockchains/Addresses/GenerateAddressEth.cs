using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressEth()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GenerateAddress(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GenerateAddressEth executed successfully, " +
          $"new address is {response.Payload.Address}"
        : $"GenerateAddressEth error: {response.ErrorMessage}");
    }
  }
}