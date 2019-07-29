using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void SendTransactionDoge()
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Testnet;
      var hexEncodedInfo = "0100000002cc9c4bc91cd5aa3221b480c7dc5b2c6f4712486d0608e95dd09917f7d2d96307010000006a47304402206f71b8e34ca542fce412d56920fa8131d56bfeb477cd4f727eb4a7cc2cbf634502202292e942a7caf97f7d2ffa925958066583b88bc4b1cab808e3a627c16cdd8b1c012102062f7d2ed743290127e66bb631195391e8233948922cc06006c0fbc5c859bf2dffffffffd1cdd08eaafaf5f02ce590b4ef188c2ad3ffb3195f6ce2db2523c8ab28a3e72f010000006b4830450221009d25959314bd2cc34e73228c7793bf537fbc014db36e3de48537844ac05f97010220696473a40c3c5eca86e5a6c8f7e5a177e369385ec1cb187f665f7ec6d2604924012102062f7d2ed743290127e66bb631195391e8233948922cc06006c0fbc5c859bf2dffffffff0220d80ed3020000001976a914fff5827ee63cc9e8073f7ffb221c57efe1756a6088ac31b1957a000000001976a914cedde8f2a0b38593095aaca585dfebf137fb294188ac00000000";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.SendTransaction(
        coin, network, hexEncodedInfo);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"SendTransactionDoge executed successfully, " +
          $"TransactionHash is \"{response.Payload.Txid}\""
        : $"SendTransactionDoge error: {response.ErrorMessage}");
    }
  }
}