﻿using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void TransferUsingPasswordEth()
    {
      var fromAddress = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
      var toAddress = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";
      var contract = "0xe7d553c3aab5943ec097d60535fd06f1b75db43e";
      double gasPrice = 11500000000;
      double gasLimit = 60000;
      var password = "abc123456";
      double amount = 115;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Token.Transfer<TransferTokensResponse>(
          NetworkCoin.EthMainNet, fromAddress, toAddress, contract, 
          gasPrice, gasLimit, password, amount);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "TransferUsingPasswordEth executed successfully, " +
          $"TransactionHash is \"{response.Payload.Hex}\""
        : $"TransferUsingPasswordEth error: {response.ErrorMessage}");
    }
  }
}