using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateTransactionUsingPrivateKey()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;
      var fromAddress = "0xc438d912235ff5facc22c502e5bd6dc1ae14a7ff";
      var toAddress = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
      var value = 1.12;
      var privateKey = "0x17de216dff24b36c35af535c7d4d9d36f57326f3ee8aaf7fd373715c27a15b7e";
      double gasPrice = 21000000000;
      double gasLimit = 21000;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.CreateTransaction<CreateEthTransactionResponse>(
          NetworkCoin.EthRopsten, fromAddress, toAddress, privateKey, value, gasPrice, gasLimit);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateTransactionUsingPrivateKey executed successfully, " +
          $"TransactionHash is \"{response.Payload.Hex}\""
        : $"CreateTransactionUsingPrivateKey error: {response.ErrorMessage}");
    }
  }
}