﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreateAddressEth()
    {
      var url = "http://somepoint.point";
      var address = "0xe816c453a99b12bb65ea55db22a6fe70f63c2c7a";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateAddress<CreateEthAddressWebHookResponse>(
        NetworkCoin.EthRopsten, url, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateAddressEth executed successfully, HookId is \"" +
          $"{response.Payload.Id}\""
        : $"CreateAddressEth error: {response.ErrorMessage}");

      return response.Payload.Id;
    }
  }
}