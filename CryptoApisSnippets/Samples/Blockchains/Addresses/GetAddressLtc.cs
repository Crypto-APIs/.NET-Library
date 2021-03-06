﻿using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressLtc()
    {
      var address = "LgRynKyCZKWCpoX4bVenXzRYujt4GpHWuF";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(
          NetworkCoin.LtcMainNet, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressLtc executed successfully, " +
          $"balance is {response.Payload.Balance}"
        : $"GetAddressLtc error: {response.ErrorMessage}");
    }
  }
}