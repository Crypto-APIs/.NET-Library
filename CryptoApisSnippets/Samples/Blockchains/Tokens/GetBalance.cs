using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBalance()
    {
      var address = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
      var contract = "0xe7d553c3aab5943ec097d60535fd06f1b75db43e";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Token.GetBalance<GetBalanceTokenResponse>(
        NetworkCoin.EthMainNet, address, contract);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetBalance executed successfully, balance is \"{response.Payload.Balance}\""
        : $"GetBalance error: {response.ErrorMessage}");
    }
  }
}