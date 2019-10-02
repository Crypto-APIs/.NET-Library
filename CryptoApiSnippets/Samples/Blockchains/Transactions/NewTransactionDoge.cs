using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void NewTransactionDoge()
    {
      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("no3yJMxBSKzq6wuUNLN7cUssfPGTiRbb5c", 15.222),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("nrJZpzhP5baL6KirRMqLE5oWFJA25V279a", 15.222),
      };
      var fee = new Fee(1.0);
      IEnumerable <string> wifs = new[]
      {
        "ckDxktqwNyxW1YQpvgWFne2FoUWTSZ9eCpM7Nn7PaWrDRicNgxA6"
      };
            
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.NewTransaction<NewBtcTransactionResponse>(
        NetworkCoin.DogeTestNet, inputs, outputs, fee, wifs);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "NewTransactionDoge executed successfully, " +
          $"txid is \"{response.Payload.Txid}\""
        : $"NewTransactionDoge error: {response.ErrorMessage}");
    }
  }
}