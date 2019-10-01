using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void EstimateGas()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Contract.EstimateGas<EthEstimateGasContractResponse>(
        NetworkCoin.EthRinkeby);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "EstimateGas executed successfully, " +
          $"gas price is {response.Payload.GasPrice}, " +
          $"gas limit is {response.Payload.GasLimit}"
        : $"EstimateGas error: {response.ErrorMessage}");
    }
  }
}