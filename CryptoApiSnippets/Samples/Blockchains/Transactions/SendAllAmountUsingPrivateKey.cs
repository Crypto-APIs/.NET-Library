using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void SendAllAmountUsingPrivateKey()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;
      var fromAddress = "0x1b85a43e2e7f52e766ddfdfa2b901c42cb1201be";
      var toAddress = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
      var privateKey = "0x17de216dff24b36c35af535c7d4d9d36f57326f3ee8aaf7fd373715c27a15b7e";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.SendAllAmountUsingPrivateKey(
          coin, network, fromAddress, toAddress, privateKey);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"SendAllAmountUsingPrivateKey executed successfully, " +
          $"TransactionHash is \"{response.Payload.Hex}\""
        : $"SendAllAmountUsingPrivateKey error: {response.ErrorMessage}");
    }
  }
}