using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateXPubBtc()
    {
      var password = "SECRET123456";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(
        NetworkCoin.BtcMainNet, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateXPubBtc executed successfully, " +
          $"created Xpub is \"{response.Payload.Xpub}\""
        : $"CreateXPubBtc error: {response.ErrorMessage}");
    }
  }
}