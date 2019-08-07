using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GenerateAddressLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GenerateAddress(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GenerateAddressLtc executed successfully, " +
          $"new address is {response.Payload.Address}"
        : $"GenerateAddressLtc error: {response.ErrorMessage}");
    }
  }
}