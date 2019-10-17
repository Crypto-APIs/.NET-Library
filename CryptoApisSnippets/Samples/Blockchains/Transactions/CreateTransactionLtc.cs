using System;
using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateTransactionLtc()
    {
      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9", 0.54),
        new TransactionAddress("1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q", 1.0),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("1EdcP2TSFsiQHNGvbbgsxgH7HfaFC54GwF", 1.54),
      };
      var fee = new Fee(0.00023141);

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.CreateTransaction<CreateBtcTransactionResponse>(
        NetworkCoin.LtcMainNet, inputs, outputs, fee);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateTransactionLtc executed successfully, " +
          $"HexEncodedInfo is \"{response.Payload.Hex}\""
        : $"CreateTransactionLtc error: {response.ErrorMessage}");
    }
  }
}