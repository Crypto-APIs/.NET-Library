﻿using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
    partial class BlockchainSnippets
    {
        public void AddAddressBch(string walletName, string[] addresses)
        {
            var coin = BtcSimilarCoin.Bch;
            var network = BtcSimilarNetwork.Mainnet;

            var manager = new CryptoManager(ApiKey);
            var response = manager.Blockchains.Wallet.AddAddress(
              coin, network, walletName, addresses);

            Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
              ? $"AddAddressBch executed successfully, " +
                $"{addresses.Length} addresses was added to \"{response.Wallet.Name}\" wallet"
              : $"AddAddressBch error: {response.ErrorMessage}");
        }
    }
}