using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void SendTransactionDash()
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;
      var hexEncodedInfo = "02000000012dbde4adf0ce369cbf98ea01be40b1c927ae59b7fc29a8a782fb7aedafcab9d3010000006b483045022100c32647dbce66670d27b9d5b6ab038a3abc1f37651f557e1add465a2ce3d3e25e02201cd797562b1839b2e52e125537fbab47f81a687d4c06249d40f8b8e23c8ac9930121039105ae7b049b8495108ba7409c8e2199713b0690987eb39ad5a020d7531857faffffffff0220f4027f000000001976a9140b974dc2170aaf6759800466b93ecb9305c2924888ac16507702000000001976a91468a3b32fd54f6998f92d155cfb23b662acc4bb5288ac00000000";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.SendTransaction(
        coin, network, hexEncodedInfo);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "SendTransactionDash executed successfully, " +
          $"TransactionHash is \"{response.Payload.Txid}\""
        : $"SendTransactionDash error: {response.ErrorMessage}");
    }
  }
}