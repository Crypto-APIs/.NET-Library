using CryptoApisSdkLibrary.DataTypes;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void NewHdTransactionDash()
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;
      var wallet = "demohdwallet";
      var password = "8a0690d2cd4fad1371090225217bb1425b3700210f51be6111eb225d5142ac32";

      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("msD7uHJ4p1MTuca6sa7gzks1bf8wmzvgSN", 0.007),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("yVrjEE1zwXckCMXZoTStJtb9SJ29xr1ZMc", 2.004),
      };
      var fee = new Fee(0.00023141);


      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.NewHdTransaction(
        coin, network, wallet, password, inputs, outputs, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"NewHdTransactionDash executed successfully, " +
          $"txid is \"{response.Payload.Txid}\""
        : $"NewHdTransactionDash error: {response.ErrorMessage}");
    }
  }
}