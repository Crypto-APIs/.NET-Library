using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void TransferUsingPrivateKeyEtc()
    {
      var fromAddress = "0xcbb36e2019f03c7d6dc8536b0d32e31aef18bded";
      var toAddress = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
      var contract = "0x3d045fcf9d7009450ca6c504ac164adba42dbbd3";
      double gasPrice = 11500000000;
      double gasLimit = 60000;
      var privateKey = "0xeb38783ad75d8081fb9105baee6ac9413c4abd732ef889116714f271cde6aed";
      double amount = 115.221;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Token.Transfer<TransferTokensResponse>(
          NetworkCoin.EtcMainNet, fromAddress, toAddress, contract,
          gasPrice, gasLimit, amount, privateKey);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "TransferUsingPrivateKeyEtc executed successfully, " +
          $"TransactionHash is \"{response.Payload.Hex}\""
        : $"TransferUsingPrivateKeyEtc error: {response.ErrorMessage}");
    }
  }
}