﻿using System;
using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void NewHdTransactionBch()
    {
      var wallet = "demohdwallet";
      var password = "8a0690d2cd4fad1371090225217bb1425b3700210f51be6111eb225d5142ac32";

      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("msD7uHJ4p1MTuca6sa7gzks1bf8wmzvgSN", 0.007),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("my4TmbbhJCLJB9q1eHUHQWJfbbJoYdLwtE", 0.007),
      };
      var fee = new Fee("bchtest:qzqyyz4m5v6v4wthvadmfwxdw4mzlmusfyyrnk73ut", 0.00023141);


      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
        NetworkCoin.BchMainNet, wallet, password, inputs, outputs, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "NewHdTransactionBch executed successfully, " +
          $"txid is \"{response.Payload.Txid}\""
        : $"NewHdTransactionBch error: {response.ErrorMessage}");
    }
  }
}