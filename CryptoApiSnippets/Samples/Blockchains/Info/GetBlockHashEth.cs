﻿using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBlockHashEth()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Mainnet;
      var blockHash = "0x79230d974f6cea8c11cc2f3a58c2b811313af17a2f7391de6665502910d4d383";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetBlockHash(coin, network, blockHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetBlockHashEth executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetBlockHashEth error: {response.ErrorMessage}");
    }
  }
}