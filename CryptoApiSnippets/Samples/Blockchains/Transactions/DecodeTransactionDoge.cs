using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DecodeTransactionDoge()
    {
      var hexEncodedInfo = "0100000002cc9c4bc91cd5aa3221b480c7dc5b2c6f4712486d0608e95dd09917f7d2d963070100000000ffffffffd1cdd08eaafaf5f02ce590b4ef188c2ad3ffb3195f6ce2db2523c8ab28a3e72f0100000000ffffffff0220d80ed3020000001976a914fff5827ee63cc9e8073f7ffb221c57efe1756a6088ac31b1957a000000001976a914cedde8f2a0b38593095aaca585dfebf137fb294188ac00000000";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.DecodeTransaction<BtcDecodeTransactionResponse>(
        NetworkCoin.DogeMainNet, hexEncodedInfo);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DecodeTransactionDoge executed successfully, " +
          $"Transaction hash is \"{response.Transaction.Hash}\""
        : $"DecodeTransactionDoge error: {response.ErrorMessage}");
    }
  }
}