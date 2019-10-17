using CryptoApisLibrary.DataTypes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoApisLibrary.RequestTypes
{
    internal class NewBtcTransactionRequest
    {
        public NewBtcTransactionRequest(IEnumerable<TransactionAddress> inputs, IEnumerable<TransactionAddress> outputs, Fee fee,
            IEnumerable<string> wifs)
        {
            CreateTx = new CreateTx(fee);
            foreach (var input in inputs)
            {
                CreateTx.Inputs.Add(new TransactionItem(input.Address, input.Value));
            }
            foreach (var output in outputs)
            {
                CreateTx.Outputs.Add(new TransactionItem(output.Address, output.Value));
            }

            Wifs.AddRange(wifs);
        }

        [JsonProperty(PropertyName = "createTx")]
        public CreateTx CreateTx { get; }

        [JsonProperty(PropertyName = "wifs")]
        public List<string> Wifs { get; } = new List<string>();
    }

    internal class CreateTx
    {
        public CreateTx(Fee fee)
        {
            Fee = new FeeRequest(fee.Value, fee.Address);
        }

        [JsonProperty(PropertyName = "inputs")]
        public List<TransactionItem> Inputs { get; } = new List<TransactionItem>();

        [JsonProperty(PropertyName = "outputs")]
        public List<TransactionItem> Outputs { get; } = new List<TransactionItem>();

        [JsonProperty(PropertyName = "fee")]
        public FeeRequest Fee { get; }
    }
}