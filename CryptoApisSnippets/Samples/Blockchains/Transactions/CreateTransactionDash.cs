using System;
using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateTransactionDash()
    {
      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("yVrjEE1zwXckCMXZoTStJtb9SJ29xr1ZMc", 21.309),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("yMNjY5gZs5RwUovbL1NzXjbnkgPMYfUA98", 21.309),
      };
      var fee = new Fee(0.00023141);

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
        NetworkCoin.DashMainNet, inputs, outputs, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateTransactionDash executed successfully, " +
          $"HexEncodedInfo is \"{response.Payload.Hex}\""
        : $"CreateTransactionDash error: {response.ErrorMessage}");
    }
  }
}