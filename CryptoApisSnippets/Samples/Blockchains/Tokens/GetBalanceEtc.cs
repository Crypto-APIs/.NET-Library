using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBalanceEtc()
    {
      var address = "0x737165b2913122aF76e05a3E6bbF2a6128484662";
      var contract = "0x1BE6D61B1103D91F7f86D47e6ca0429259A15ff0";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(
        NetworkCoin.EtcMainNet, address, contract);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetBalanceEtc executed successfully, balance is \"{response.Payload.Balance}\""
        : $"GetBalanceEtc error: {response.ErrorMessage}");
    }
  }
}