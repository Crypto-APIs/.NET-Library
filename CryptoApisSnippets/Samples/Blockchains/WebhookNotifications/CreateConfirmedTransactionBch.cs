﻿using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateConfirmedTransactionBch()
    {
      var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
      var transactionHash = "9bba7c4a8121f4bf9819ea481f4abd5e501db40815e23a70dfcb9e99eb9ba05e";
      var confirmationCount = 6;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.
        CreateConfirmedTransaction<CreateBtcConfirmedTransactionWebHookResponse>(
          NetworkCoin.BchMainNet, url, transactionHash, confirmationCount);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateConfirmedTransactionBch executed successfully, " +
          $"HookId is \"{response.Hook.Id}\""
        : $"CreateConfirmedTransactionBch error: {response.ErrorMessage}");
    }
  }
}