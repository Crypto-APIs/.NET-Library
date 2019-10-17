using System;
using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void NewHdTransactionDoge()
    {
      var wallet = "demohdwallet";
      var password = "8a0690d2cd4fad1371090225217bb1425b3700210f51be6111eb225d5142ac32";

      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("msD7uHJ4p1MTuca6sa7gzks1bf8wmzvgSN", 12.004),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("nsXYgWCuBVSYxD1rWz543EFkfxcPV9PC2y", 12.004),
      };
      var fee = new Fee(1.00023141);


      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.NewHdTransaction<NewBtcTransactionResponse>(
        NetworkCoin.DogeMainNet, wallet, password, inputs, outputs, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "NewHdTransactionDoge executed successfully, " +
          $"txid is \"{response.Payload.Txid}\""
        : $"NewHdTransactionDoge error: {response.ErrorMessage}");
    }
  }
}