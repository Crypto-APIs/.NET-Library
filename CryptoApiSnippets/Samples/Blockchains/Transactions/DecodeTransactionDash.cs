using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DecodeTransactionDash()
    {
      var hexEncodedInfo = "02000000012dbde4adf0ce369cbf98ea01be40b1c927ae59b7fc29a8a782fb7aedafcab9d30100000000ffffffff0220f4027f000000001976a9140b974dc2170aaf6759800466b93ecb9305c2924888ac16507702000000001976a91468a3b32fd54f6998f92d155cfb23b662acc4bb5288ac00000000";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.DecodeTransaction<BtcDecodeTransactionResponse>(
        NetworkCoin.DashMainNet, hexEncodedInfo);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DecodeTransactionDash executed successfully, " +
          $"Transaction hash is \"{response.Transaction.Hash}\""
        : $"DecodeTransactionDash error: {response.ErrorMessage}");
    }
  }
}