﻿using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBlockHashBtc()
    {
      var blockHash = "00000000000000000013dc04902f71e2a4b16d45497eb189beb805e57c5ce1e4";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(
        NetworkCoin.BtcMainNet, blockHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetBlockHashBtc executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetBlockHashBtc error: {response.ErrorMessage}");
    }
  }
}