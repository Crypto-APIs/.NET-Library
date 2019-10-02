using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void NewHdTransactionLtc()
    {
      var wallet = "demohdwallet";
      var password = "8a0690d2cd4fad1371090225217bb1425b3700210f51be6111eb225d5142ac32";

      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("mkZg2uqHchJ5ZmsRXgkrcSdEvzaA1Bb3SW", 0.007),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("miLR7Grn6Fqqq3hncmqdNkXh2WEKpaqJLP", 0.007),
      };
      var fee = new Fee(0.00023141);


      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
        NetworkCoin.LtcMainNet, wallet, password, inputs, outputs, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "NewHdTransactionLtc executed successfully, " +
          $"txid is \"{response.Payload.Txid}\""
        : $"NewHdTransactionLtc error: {response.ErrorMessage}");
    }
  }
}