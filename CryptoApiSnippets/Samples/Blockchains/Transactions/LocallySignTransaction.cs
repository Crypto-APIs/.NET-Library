using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void LocallySignTransaction()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Mainnet;
      var fromAddress = "0x1b85a43e2e7f52e766ddfdfa2b901c42cb1201be";
      var toAddress = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
      var value = 1.212;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.LocallySignTransaction(
        coin, network, fromAddress, toAddress, value);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"LocallySignTransaction executed successfully, " +
          $"transfered \"{response.Payload.Value}\""
        : $"LocallySignTransaction error: {response.ErrorMessage}");
    }
  }
}