using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;
using System.Collections.Generic;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void NewTransactionBtc()
    {
      IEnumerable<TransactionAddress> inputs = new[]
      {
        new TransactionAddress("mtFYoSowT3i649wnBDYjCjewenh8AuofQb", 0.00009),
        new TransactionAddress("mn6GtNFRPwXtW7xJqH8Afck7FbVoRi6NF1", 0.00004),
        new TransactionAddress("mrnWMV41vXivQX9yiY9ACSK5uPo3TfJdv9", 0.00005),
      };
      IEnumerable<TransactionAddress> outputs = new[]
      {
        new TransactionAddress("mmskWH7hG9CJNzb16JaVFJyWdgAwcVEAkz", 0.00018),
      };
      var fee = new Fee("mmskWH7hG9CJNzb16JaVFJyWdgAwcVEAkz", 0.00023141);
      IEnumerable <string> wifs = new[]
      {
        "cUGddnJmuzfzpWXNwt1SRnQ8GMqZdQ1vg8BtwjG8f275pvExPzaX",
        "cSEjySAREyai8eQhgoqixzmxCeSP8QtbwHxptL8ijofg68ZMjoud",
        "cV2u6dqfiQthWfPixJ7ucFW5Tza1ubLr6ipM35vSTy9xGEKbCbaJ"
      };
            
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.NewTransaction<NewBtcTransactionResponse>(
        NetworkCoin.BtcMainNet, inputs, outputs, fee, wifs);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "NewTransactionBtc executed successfully, " +
          $"txid is \"{response.Payload.Txid}\""
        : $"NewTransactionBtc error: {response.ErrorMessage}");
    }
  }
}