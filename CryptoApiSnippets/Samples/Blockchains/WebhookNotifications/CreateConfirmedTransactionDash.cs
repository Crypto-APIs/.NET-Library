﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateConfirmedTransactionDash()
    {
      var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
      var transactionHash = "9bba7c4a8121f4bf9819ea481f4abd5e501db40815e23a70dfcb9e99eb9ba05e";
      var confirmationCount = 6;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.
        CreateConfirmedTransaction<CreateBtcConfirmedTransactionWebHookResponse>(
          NetworkCoin.DashMainNet, url, transactionHash, confirmationCount);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateConfirmedTransactionDash executed successfully, " +
          $"HookId is \"{response.Payload.Id}\""
        : $"CreateConfirmedTransactionDash error: {response.ErrorMessage}");
    }
  }
}