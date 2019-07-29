using CryptoApisSdkLibrary.DataTypes;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void NewTransactionDash()
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;
      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("yMNjY5gZs5RwUovbL1NzXjbnkgPMYfUA98", 5.222),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("yguXUVGiC8C6e2taikbA7VM1Q3ncAtbr7k", 5.222),
      };
      var fee = new Fee(0.00000271);
      IEnumerable <string> wifs = new[]
      {
        "cU4i8Mox2MVgV64LC8eEbHqhp4rithrhguBgfAgB7725neiVBiVh"
      };
            
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.NewTransaction(
        coin, network, inputs, outputs, fee, wifs);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"NewTransactionDash executed successfully, " +
          $"txid is \"{response.Payload.Txid}\""
        : $"NewTransactionDash error: {response.ErrorMessage}");
    }
  }
}