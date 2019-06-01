using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBalance()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Mainnet;
      var address = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
      var contract = "0xe7d553c3aab5943ec097d60535fd06f1b75db43e";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Token.GetBalance(
        coin, network, address, contract);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetBalance executed successfully, balance is \"{response.Payload.Balance}\""
        : $"GetBalance error: {response.ErrorMessage}");
    }
  }
}