using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void EstimateGas()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Rinkeby;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Contract.EstimateGas(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"EstimateGas executed successfully, " +
          $"gas price is {response.Payload.GasPrice}, gas limit is {response.Payload.GasLimit}"
        : $"EstimateGas error: {response.ErrorMessage}");
    }
  }
}