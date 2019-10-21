using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetTokenTotalSupplyAndDecimalsEtc()
    {
      var contract = "0x085fb4f24031EAedbC2B611AA528f22343eB52Db";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Token.GetTokenTotalSupplyAndDecimals<GetTokenTotalSupplyAndDecimalsResponse>(
        NetworkCoin.EtcMainNet, contract);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetTokenTotalSupplyAndDecimalsEtc executed successfully, " +
          $"TotalSupply is \"{response.Payload.TotalSupply}\""
        : $"GetTokenTotalSupplyAndDecimalsEtc error: {response.ErrorMessage}");
    }
  }
}