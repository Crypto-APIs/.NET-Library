using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void NewTransactionLtc()
    {
      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("my4TmbbhJCLJB9q1eHUHQWJfbbJoYdLwtE", 0.00309),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("mkjKTdPRKX2CuH1fQHdcaWF8tYDLpNftKP", 0.00309),
      };
      var fee = new Fee(0.00023141);
      IEnumerable <string> wifs = new[]
      {
        "cSKbuySxbKm4uQK9SQQRjpsZfENNBrFxKm3rmoMER9ua6XR79Shs",
      };
            
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.NewTransaction<NewBtcTransactionResponse>(
        NetworkCoin.LtcMainNet, inputs, outputs, fee, wifs);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "NewTransactionLtc executed successfully, " +
          $"txid is \"{response.Payload.Txid}\""
        : $"NewTransactionLtc error: {response.ErrorMessage}");
    }
  }
}