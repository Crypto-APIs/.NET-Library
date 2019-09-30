using CryptoApisSdkLibrary.DataTypes;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void NewTransactionBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;
      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("bchtest:qrqxlge4wjv7kttm0u9srqjttprhylsz6g84fhjgzf", 0.00109),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("qzsq3lqt2s08635y54h96la8002jy5tvlshrnskeux", 0.00109),
      };
      var fee = new Fee(0.00023141);
      IEnumerable <string> wifs = new[]
      {
        "cSKbuySxbKm4uQK9SQQRjpsZfENNBrFxKm3rmoMER9ua6XR79Shs"
      };
            
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.NewTransaction(
        coin, network, inputs, outputs, fee, wifs);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "NewTransactionBch executed successfully, " +
          $"txid is \"{response.Payload.Txid}\""
        : $"NewTransactionBch error: {response.ErrorMessage}");
    }
  }
}