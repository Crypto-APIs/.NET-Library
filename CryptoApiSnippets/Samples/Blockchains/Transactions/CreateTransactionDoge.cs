using CryptoApisSdkLibrary.DataTypes;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateTransactionDoge()
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Mainnet;
      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("no3yJMxBSKzq6wuUNLN7cUssfPGTiRbb5c", 121.39),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("nsXYgWCuBVSYxD1rWz543EFkfxcPV9PC2y", 121.39),
      };
      var fee = new Fee(1.00023141);

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.CreateTransaction(
        coin, network, inputs, outputs, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"CreateTransactionDoge executed successfully, " +
          $"HexEncodedInfo is \"{response.Payload.Hex}\""
        : $"CreateTransactionDoge error: {response.ErrorMessage}");
    }
  }
}