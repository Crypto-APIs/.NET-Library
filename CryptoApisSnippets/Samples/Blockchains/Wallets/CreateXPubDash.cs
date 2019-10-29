using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateXPubDash()
    {
      var password = "SECRET123456";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(
        NetworkCoin.DashMainNet, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateXPubDash executed successfully, " +
          $"created Xpub is \"{response.Payload.Xpub}\""
        : $"CreateXPubDash error: {response.ErrorMessage}");
    }
  }
}