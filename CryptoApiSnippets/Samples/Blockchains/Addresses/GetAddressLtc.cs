using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;
      var address = "LgRynKyCZKWCpoX4bVenXzRYujt4GpHWuF";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddress(
          coin, network, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressLtc executed successfully, " +
          $"balance is {response.Payload.Balance}"
        : $"GetAddressLtc error: {response.ErrorMessage}");
    }
  }
}