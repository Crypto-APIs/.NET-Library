﻿using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHookBch(string hookId)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(
        NetworkCoin.BchMainNet, hookId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteHookBch executed successfully, Status is \"" +
          $"{response.Payload.Message}\""
        : $"DeleteHookBch error: {response.ErrorMessage}");
    }
  }
}