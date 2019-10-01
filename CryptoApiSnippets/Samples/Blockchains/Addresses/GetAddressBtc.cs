using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressBtc()
    {
      var address = "1DBrYbe5U7LGDcHA5tiLCxivZ7JZAGqGhJ";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddress<GetBtcAddressResponse>(
          NetworkCoin.BtcMainNet, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressBtc executed successfully, " +
          $"balance is {response.Payload.Balance}"
        : $"GetAddressBtc error: {response.ErrorMessage}");
    }
  }
}