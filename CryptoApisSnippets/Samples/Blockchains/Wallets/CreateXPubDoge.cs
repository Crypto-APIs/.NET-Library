using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateXPubDoge()
    {
      var password = "SECRET123456";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(
        NetworkCoin.DogeMainNet, password);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateXPubDoge executed successfully, " +
          $"created Xpub is \"{response.Payload.Xpub}\""
        : $"CreateXPubDoge error: {response.ErrorMessage}");
    }
  }
}