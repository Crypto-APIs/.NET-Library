using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressBalanceEth()
    {
      var address = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddressBalance<GetEthAddressBalanceResponse>(
        NetworkCoin.EthRopsten, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressBalanceEth executed successfully, " +
          $"balance is {response.Payload.Balance} now"
        : $"GetAddressBalanceEth error: {response.ErrorMessage}");
    }
  }
}