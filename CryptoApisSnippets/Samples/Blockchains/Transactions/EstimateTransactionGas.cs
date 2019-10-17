using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void EstimateTransactionGas()
    {
      var fromAddress = "0x7857af2143cb06ddc1dab5d7844c9402e89717cb";
      var toAddress = "0xc595B20EEC3d35E8f993d79262669F3ADb6328f7";
      var value = 0.12;
      var data = "24224747A80F225FD841E7AB2806A2FDF78525B58C1BC1F5D5A5D3943B4214B6C350CE0D973CAD81BD7A6E57048A487939D7CD6373BF8C9F3ADB6328f7";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
        NetworkCoin.EthMainNet, fromAddress, toAddress, value, data);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "EstimateTransactionGas executed successfully, " +
          $"gas needed {response.Payload.GasNeeded}"
        : $"EstimateTransactionGas error: {response.ErrorMessage}");
    }
  }
}