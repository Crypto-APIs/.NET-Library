using System;
using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void SignTransactionDash()
    {
      var hexEncodedInfo =
        "02000000012dbde4adf0ce369cbf98ea01be40b1c927ae59b7fc29a8a782fb7aedafcab9d30100000000ffffffff0220f4027f000000001976a9140b974dc2170aaf6759800466b93ecb9305c2924888ac16507702000000001976a91468a3b32fd54f6998f92d155cfb23b662acc4bb5288ac00000000";
      var wifs = new List<string> { "cVcBtNotRXr9BtcfkC9EPp2fsS6mDHE67o4y1bh6Q3pEKuvPqaJA" };
            
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.SignTransaction<SignBtcTransactionResponse>(
        NetworkCoin.DashTestNet, hexEncodedInfo, wifs);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "SignTransactionDash executed successfully, " +
          $"return hex is {response.Payload.Hex}"
        : $"SignTransactionDash error: {response.ErrorMessage}");
    }
  }
}