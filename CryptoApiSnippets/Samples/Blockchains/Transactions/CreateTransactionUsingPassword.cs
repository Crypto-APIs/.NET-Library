using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateTransactionUsingPassword()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;
      var fromAddress = "0xc438d912235ff5facc22c502e5bd6dc1ae14a7ff";
      var toAddress = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
      var value = 1.12;
      var password = "123456";
      double gasPrice = 21000000000;
      double gasLimit = 21000;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.CreateTransaction(
          coin, network, fromAddress, toAddress, value, password, gasPrice, gasLimit);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateTransactionUsingPassword executed successfully, " +
          $"TransactionHash is \"{response.Payload.Hex}\""
        : $"CreateTransactionUsingPassword error: {response.ErrorMessage}");
    }
  }
}