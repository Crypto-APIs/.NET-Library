using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void SendAllAmountUsingPassword()
    {
      var fromAddress = "0xc438d912235ff5facc22c502e5bd6dc1ae14a7ff";
      var toAddress = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
      var password = "123456";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
          NetworkCoin.EthRopsten, fromAddress, toAddress, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "SendAllAmountUsingPassword executed successfully, " +
          $"TransactionHash is \"{response.Payload.Hex}\""
        : $"SendAllAmountUsingPassword error: {response.ErrorMessage}");
    }
  }
}