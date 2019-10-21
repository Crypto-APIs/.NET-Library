using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains.Payloads
{
    public abstract class GetHashInfoPayload
    {
        [DeserializeAs(Name = "hash")]
        public string Hash { get; protected set; }

        [DeserializeAs(Name = "height")]
        public int Height { get; protected set; }

        [DeserializeAs(Name = "difficulty")]
        public double Difficulty { get; protected set; }

        [DeserializeAs(Name = "confirmations")]
        public int Confirmations { get; protected set; }

        [DeserializeAs(Name = "timestamp")]
        public DateTime Timestamp { get; protected set; }
    }

    public class GetBtcHashInfoPayload : GetHashInfoPayload
    {
        [DeserializeAs(Name = "strippedsize")]
        public int StrippedSize { get; protected set; }

        [DeserializeAs(Name = "size")]
        public int Size { get; protected set; }

        [DeserializeAs(Name = "weight")]
        public int Weight { get; protected set; }

        [DeserializeAs(Name = "version")]
        public int Version { get; protected set; }

        [DeserializeAs(Name = "versionHex")]
        public string VersionHex { get; protected set; }

        [DeserializeAs(Name = "merkleroot")]
        public string MerkleRoot { get; protected set; }

        [DeserializeAs(Name = "time")]
        public string Time { get; protected set; }

        [DeserializeAs(Name = "mediantime")]
        public string Mediantime { get; protected set; }

        [DeserializeAs(Name = "nonce")]
        public long Nonce { get; protected set; }

        [DeserializeAs(Name = "bits")]
        public string Bits { get; protected set; }

        [DeserializeAs(Name = "chainwork")]
        public string Chainwork { get; protected set; }

        [DeserializeAs(Name = "previousblockhash")]
        public string PreviousBlockHash { get; protected set; }

        [DeserializeAs(Name = "nextblockhash")]
        public string NextBlockHash { get; protected set; } // todo: #027 no BCH TestNet for "Latest block" endpoint
        // todo: после #027 разделить response для GetLatestBlock и для GetBlockHeight. Этого поля в GetLatestBlock нет. Чтобы не вводить в заблуждение пользователей.

        [DeserializeAs(Name = "transactions")]
        public int Transactions { get; protected set; }

        [DeserializeAs(Name = "tx")]
        public List<string> Tx { get; protected set; } = new List<string>();
    }

    public class GetEthHashInfoPayload : GetHashInfoPayload
    {
        [DeserializeAs(Name = "chain")]
        public string Chain { get; protected set; }

        [DeserializeAs(Name = "parent_hash")]
        public string ParentHash { get; protected set; }

        [DeserializeAs(Name = "sha3Uncles")]
        public string Sha3Uncles { get; protected set; }

        [DeserializeAs(Name = "gas_used")]
        public int GasUsed { get; protected set; }

        /* нет в https://docs.cryptoapis.io/rest-apis/blockchain-as-a-service-apis/etc/index#etc-block-hash-endpoint
         если нигде больше не надо, удалить вообще
         [DeserializeAs(Name = "total")]
        public long Total { get; protected set; } */

        [DeserializeAs(Name = "size")]
        public string Size { get; protected set; }

        [DeserializeAs(Name = "date")]
        public string Date { get; protected set; }

        [DeserializeAs(Name = "transactions")]
        public int Transactions { get; protected set; }

        [DeserializeAs(Name = "total_difficulty")]
        public string TotalDifficulty { get; protected set; }

        [DeserializeAs(Name = "total_fees")]
        public string TotalFees { get; protected set; }

        [DeserializeAs(Name = "gas_limit")]
        public int GasLimit { get; protected set; }

        [DeserializeAs(Name = "nonce")]
        public string Nonce { get; protected set; }

        [DeserializeAs(Name = "mined_by")]
        public string MinedBy { get; protected set; }

        [DeserializeAs(Name = "extra_data")]
        public string ExtraData { get; protected set; }

        [DeserializeAs(Name = "uncles")]
        public List<string> Uncles { get; private set; } = new List<string>();
    }
}