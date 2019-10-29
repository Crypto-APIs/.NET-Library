using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetXPubReceiveAddressesDash()
    {
      var xpub = "11113cjQ3DY79arEcWZbF3FnYHN8ZvXMKhhZAorVVskdRCW5zmY1wPkGfyYJDvNo1952VN1NWehxk4igFzysfrLydPdixxQYDFCEDo9GQQ2x3v";
      var startIndex = 0;
      var finishIndex = 3;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Wallet.GetXPubReceiveAddresses<GetXPubAddressesResponse>(
        NetworkCoin.DashMainNet, xpub, startIndex, finishIndex);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetXPubReceiveAddressesDash executed successfully, " +
          $"\"{response.Addresses.Count}\" addresses were created "
        : $"GetXPubReceiveAddressesDash error: {response.ErrorMessage}");
    }
  }
}