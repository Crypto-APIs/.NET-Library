using CryptoApiSnippets.Samples.Blockchains;
using CryptoApiSnippets.Samples.Exchanges;
using System;

namespace CryptoApiSnippets
{
    internal static class DemoProgram
    {
        private static void Main(string[] args)
        {
            RunExchangesFeatures(new ExchangeSnippets());
            RunBlockchainsFeatures(new BlockchainSnippets());

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        private static void RunExchangesFeatures(ExchangeSnippets snippets)
        {
            snippets.GetExchanges();
            snippets.GetAssets();
            snippets.GetSymbols();
            snippets.GetExchangeRate();
            snippets.GetCurrentRates();
            snippets.GetPeriods();
            snippets.GetLatestData();
            snippets.GetHistoricalData();
            snippets.GetLatestSymbolTrades();
            snippets.GetLatestTrades();
            snippets.GetHistoricalTrades();
            snippets.GetLatestQuoteTrades();
            snippets.GetHistoricalQuoteTrades();
            snippets.GetArbitrageInfo();
        }

        private static void RunBlockchainsFeatures(BlockchainSnippets snippets)
        {
            RunInfoBlockchainsFeatures(snippets);
            RunAddressBlockchainsFeatures(snippets);
            RunWalletBlockchainsFeatures(snippets);
            RunTransactionBlockchainsFeatures(snippets);
            RunPaymentForwardingBlockchainsFeatures(snippets);
            RunWebhookNotificationBlockchainsFeatures(snippets);
            RunContractBlockchainsFeatures(snippets);
            RunTokenBlockchainsFeatures(snippets);
        }

        private static void RunInfoBlockchainsFeatures(BlockchainSnippets snippets)
        {
            snippets.GetInfoBtc();
            snippets.GetInfoEth();
            snippets.GetInfoBch();
            snippets.GetInfoLtc();
            snippets.GetInfoDoge();

            snippets.GetBlockHashBtc();
            snippets.GetBlockHashEth();
            snippets.GetBlockHashBch();
            snippets.GetBlockHashLtc();
            snippets.GetBlockHashDoge();

            snippets.GetBlockHeightBtc();
            snippets.GetBlockHeightEth();
            snippets.GetBlockHeightBch();
            snippets.GetBlockHeightLtc();
            snippets.GetBlockHeightDoge();

            snippets.GetLatestBlockBtc();
            snippets.GetLatestBlockEth();
            snippets.GetLatestBlockBch();
            snippets.GetLatestBlockLtc();
            snippets.GetLatestBlockDoge();
        }

        private static void RunAddressBlockchainsFeatures(BlockchainSnippets snippets)
        {
            snippets.GetAddressBtc();
            snippets.GetAddressEth();
            snippets.GetAddressBch();
            snippets.GetAddressLtc();
            snippets.GetAddressDoge();

            snippets.GetAddressInMultisignatureAddressesBtc();
            snippets.GetAddressInMultisignatureAddressesBch();
            snippets.GetAddressInMultisignatureAddressesLtc();
            snippets.GetAddressInMultisignatureAddressesDoge();

            snippets.GenerateAddressBtc();
            snippets.GenerateAddressEth();
            snippets.GenerateAddressBch();
            snippets.GenerateAddressLtc();
            snippets.GenerateAddressDoge();

            snippets.GetAddressTransactionsBtc();
            snippets.GetAddressTransactionsEth();
            snippets.GetAddressTransactionsBch();
            snippets.GetAddressTransactionsLtc();
            snippets.GetAddressTransactionsDoge();

            snippets.GenerateAccountEth();
            snippets.GetAddressBalanceEth();
        }

        private static void RunWalletBlockchainsFeatures(BlockchainSnippets snippets)
        {
            var btcWallet = snippets.CreateWalletBtc();
            snippets.GetWalletsBtc();
            snippets.GetWalletBtc(btcWallet);
            var btcAddresses = new[] { "1KRYkrh3dAkeBWPwxDZhrz9u8xf5NRK9UH", "1Ho72xi1JDv7inZ7BrLivJShSkcwARtP2R" };
            snippets.AddAddressBtc(btcWallet, btcAddresses);
            snippets.GenerateAddressesBtc(btcWallet);
            snippets.RemoveAddressesBtc(btcWallet, btcAddresses[0]);
            snippets.DeleteWalletBtc(btcWallet);

            var bchWallet = snippets.CreateWalletBch();
            snippets.GetWalletsBch();
            snippets.GetWalletBch(bchWallet);
            var bchAddresses = new[] { "1KRYkrh3dAkeBWPwxDZhrz9u8xf5NRK9UH", "1Ho72xi1JDv7inZ7BrLivJShSkcwARtP2R" };
            snippets.AddAddressBch(bchWallet, bchAddresses);
            snippets.GenerateAddressesBch(bchWallet);
            snippets.RemoveAddressesBch(bchWallet, bchAddresses[0]);
            snippets.DeleteWalletBch(bchWallet);

            var ltcWallet = snippets.CreateWalletLtc();
            snippets.GetWalletsLtc();
            snippets.GetWalletLtc(ltcWallet);
            var ltcAddresses = new[] { "Lad4PXW9HWQctdJVqcC97kSMzRw6iYRSjw", "LYXF1zZwXzMDWimEWzz4csoMaKfnwHMGxD" };
            snippets.AddAddressLtc(ltcWallet, ltcAddresses);
            snippets.GenerateAddressesLtc(ltcWallet);
            snippets.RemoveAddressesLtc(ltcWallet, ltcAddresses[0]);
            snippets.DeleteWalletLtc(ltcWallet);

            var dogeWallet = snippets.CreateWalletDoge();
            snippets.GetWalletsDoge();
            snippets.GetWalletDoge(dogeWallet);
            var dogeAddresses = new[] { "Lad4PXW9HWQctdJVqcC97kSMzRw6iYRSjw", "LYXF1zZwXzMDWimEWzz4csoMaKfnwHMGxD" };
            snippets.AddAddressDoge(dogeWallet, dogeAddresses);
            snippets.GenerateAddressesDoge(dogeWallet);
            snippets.RemoveAddressesDoge(dogeWallet, dogeAddresses[0]);
            snippets.DeleteWalletDoge(dogeWallet);

            var btcHdWallet = snippets.CreateHierarchicalDeterministicWalletBtc();
            snippets.GetHierarchicalDeterministicWalletsBtc();
            snippets.GetHierarchicalDeterministicWalletBtc(btcHdWallet);
            // snippets.AddHierarchicalDeterministicBtcAddress(); todo: this is not implemented?
            snippets.GenerateHierarchicalDeterministicAddressesBtc(btcHdWallet);
            // snippets.RemoveHierarchicalDeterministicBtcAddresses(btcHdWallet, btcHdAddresses[0]); todo: this is not implemented?
            snippets.DeleteHierarchicalDeterministicWalletBtc(btcHdWallet);

            var bchHdWallet = snippets.CreateHierarchicalDeterministicWalletBch();
            snippets.GetHierarchicalDeterministicWalletsBch();
            snippets.GetHierarchicalDeterministicWalletBch(bchHdWallet);
            // snippets.AddHierarchicalDeterministicBchAddress(); todo: this is not implemented?
            snippets.GenerateHierarchicalDeterministicAddressesBch(bchHdWallet);
            // snippets.RemoveHierarchicalDeterministicBchAddresses(bchHdWallet, bchHdAddresses[0]); todo: this is not implemented?
            snippets.DeleteHierarchicalDeterministicWalletBch(bchHdWallet);

            var ltcHdWallet = snippets.CreateHierarchicalDeterministicWalletLtc();
            snippets.GetHierarchicalDeterministicWalletsLtc();
            snippets.GetHierarchicalDeterministicWalletLtc(ltcHdWallet);
            // snippets.AddHierarchicalDeterministicLtcAddress(); todo: this is not implemented?
            snippets.GenerateHierarchicalDeterministicAddressesLtc(ltcHdWallet);
            // snippets.RemoveHierarchicalDeterministicLtcAddresses(ltcHdWallet, ltcHdAddresses[0]); todo: this is not implemented?
            snippets.DeleteHierarchicalDeterministicWalletLtc(ltcHdWallet);

            var dogeHdWallet = snippets.CreateHierarchicalDeterministicWalletDoge();
            snippets.GetHierarchicalDeterministicWalletsDoge();
            snippets.GetHierarchicalDeterministicWalletDoge(dogeHdWallet);
            // snippets.AddHierarchicalDeterministicDogeAddress(); todo: this is not implemented?
            snippets.GenerateHierarchicalDeterministicAddressesDoge(dogeHdWallet);
            // snippets.RemoveHierarchicalDeterministicDogeAddresses(dogeHdWallet, dogeHdAddresses[0]); todo: this is not implemented?
            snippets.DeleteHierarchicalDeterministicWalletDoge(dogeHdWallet);
        }

        private static void RunTransactionBlockchainsFeatures(BlockchainSnippets snippets)
        {
            snippets.GetInfoByTransactionHashBtc();
            snippets.GetInfoByTransactionHashEth();
            snippets.GetInfoByTransactionHashBch();
            snippets.GetInfoByTransactionHashLtc();
            snippets.GetInfoByTransactionHashDoge();

            snippets.GetInfoByBlockHashAndTransactionIndex();
            snippets.GetInfoByBlockHeightAndTransactionIndex();

            snippets.GetInfosByBlockHeightBtc();
            snippets.GetInfosByBlockHeightEth();
            snippets.GetInfosByBlockHeightBch();
            snippets.GetInfosByBlockHeightLtc();
            snippets.GetInfosByBlockHeightDoge();

            snippets.GetInfosByBlockHashBtc();
            snippets.GetInfosByBlockHashBch();
            snippets.GetInfosByBlockHashLtc();
            snippets.GetInfosByBlockHashDoge();

            snippets.GetUnconfirmedTransactionsBtc();
            snippets.GetUnconfirmedTransactionsBch();
            snippets.GetUnconfirmedTransactionsLtc();
            snippets.GetUnconfirmedTransactionsDoge();

            snippets.CreateTransactionBtc();
            snippets.CreateTransactionBch();
            snippets.CreateTransactionLtc();
            snippets.CreateTransactionDoge();

            snippets.CreateTransactionUsingPassword();
            snippets.CreateTransactionUsingPrivateKey();

            snippets.SendAllAmountUsingPassword();
            snippets.SendAllAmountUsingPrivateKey();

            snippets.SendTransactionBtc();
            snippets.SendTransactionBch();
            snippets.SendTransactionLtc();
            snippets.SendTransactionDoge();

            snippets.LocallySignTransaction();

            snippets.NewTransactionBtc();
            snippets.NewTransactionBch();
            snippets.NewTransactionLtc();
            snippets.NewTransactionDoge();

            snippets.NewHdTransactionBtc();
            snippets.NewHdTransactionBch();
            snippets.NewHdTransactionLtc();
            snippets.NewHdTransactionDoge();

            snippets.PushTransaction();
            snippets.EstimateTransactionGas();
            snippets.PendingTransactions();
            snippets.QueuedTransactions();

            snippets.DecodeTransactionBtc();
            snippets.DecodeTransactionBch();
            snippets.DecodeTransactionLtc();
            snippets.DecodeTransactionDoge();

            snippets.TransactionsFeeBtc();
            snippets.TransactionsFeeEth();
            snippets.TransactionsFeeBch();
            snippets.TransactionsFeeLtc();
            snippets.TransactionsFeeDoge();

            snippets.SignTransactionBtc();
            snippets.SignTransactionBch();
            snippets.SignTransactionLtc();
            snippets.SignTransactionDoge();
        }

        private static void RunPaymentForwardingBlockchainsFeatures(BlockchainSnippets snippets)
        {
            var btcPaymentId = snippets.CreatePaymentBtc();
            var ethPaymentId = snippets.CreatePaymentEth();
            var bchPaymentId = snippets.CreatePaymentBch();
            var ltcPaymentId = snippets.CreatePaymentLtc();
            var dogePaymentId = snippets.CreatePaymentDoge();

            snippets.GetPaymentsBtc();
            snippets.GetPaymentsEth();
            snippets.GetPaymentsBch();
            snippets.GetPaymentsLtc();
            snippets.GetPaymentsDoge();

            snippets.GetHistoricalPaymentsBtc();
            snippets.GetHistoricalPaymentsEth();
            snippets.GetHistoricalPaymentsBch();
            snippets.GetHistoricalPaymentsLtc();
            snippets.GetHistoricalPaymentsDoge();

            snippets.DeletePaymentBtc(btcPaymentId);
            snippets.DeletePaymentEth(ethPaymentId);
            snippets.DeletePaymentBch(bchPaymentId);
            snippets.DeletePaymentLtc(ltcPaymentId);
            snippets.DeletePaymentDoge(dogePaymentId);
        }

        private static void RunWebhookNotificationBlockchainsFeatures(BlockchainSnippets snippets)
        {
            snippets.CreateNewBlockBtc();
            snippets.CreateNewBlockEth();
            snippets.CreateNewBlockBch();
            snippets.CreateNewBlockLtc();
            snippets.CreateNewBlockDoge();

            snippets.CreateConfirmedTransactionBtc();
            snippets.CreateConfirmedTransactionEth();
            snippets.CreateConfirmedTransactionBch();
            snippets.CreateConfirmedTransactionLtc();
            snippets.CreateConfirmedTransactionDoge();

            var btcHookId = snippets.CreateAddressBtc();
            var ethHookId = snippets.CreateAddressEth();
            var bchHookId = snippets.CreateAddressBch();
            var ltcHookId = snippets.CreateAddressLtc();
            var dogeHookId = snippets.CreateAddressDoge();

            snippets.CreateToken();
            snippets.CreateTransactionPool();

            snippets.GetHooksBtc();
            snippets.GetHooksEth();
            snippets.GetHooksBch();
            snippets.GetHooksLtc();
            snippets.GetHooksDoge();

            snippets.DeleteHookBtc(btcHookId);
            snippets.DeleteHookEth(ethHookId);
            snippets.DeleteHookBch(bchHookId);
            snippets.DeleteHookLtc(ltcHookId);
            snippets.DeleteHookDoge(dogeHookId);
        }

        private static void RunContractBlockchainsFeatures(BlockchainSnippets snippets)
        {
            snippets.EstimateGas();
            snippets.Deploy();
        }

        private static void RunTokenBlockchainsFeatures(BlockchainSnippets snippets)
        {
            snippets.GetBalance();
            snippets.TransferUsingPassword();
            snippets.TransferUsingPrivateKey();
            snippets.GetTokens();
        }
    }
}