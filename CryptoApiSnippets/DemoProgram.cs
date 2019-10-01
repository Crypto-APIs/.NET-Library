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
            snippets.GetInfoDash();

            snippets.GetBlockHashBtc();
            snippets.GetBlockHashEth();
            snippets.GetBlockHashBch();
            snippets.GetBlockHashLtc();
            snippets.GetBlockHashDoge();
            snippets.GetBlockHashDash();

            snippets.GetBlockHeightBtc();
            snippets.GetBlockHeightEth();
            snippets.GetBlockHeightBch();
            snippets.GetBlockHeightLtc();
            snippets.GetBlockHeightDoge();
            snippets.GetBlockHeightDash();

            snippets.GetLatestBlockBtc();
            snippets.GetLatestBlockEth();
            snippets.GetLatestBlockBch();
            snippets.GetLatestBlockLtc();
            snippets.GetLatestBlockDoge();
            snippets.GetLatestBlockDash();
        }

        private static void RunAddressBlockchainsFeatures(BlockchainSnippets snippets)
        {
            snippets.GetAddressBtc();
            snippets.GetAddressEth();
            snippets.GetAddressBch();
            snippets.GetAddressLtc();
            snippets.GetAddressDoge();
            snippets.GetAddressDash();

            snippets.GetAddressInMultisignatureAddressesBtc();
            snippets.GetAddressInMultisignatureAddressesBch();
            snippets.GetAddressInMultisignatureAddressesLtc();
            snippets.GetAddressInMultisignatureAddressesDoge();
            snippets.GetAddressInMultisignatureAddressesDash();

            snippets.GenerateAddressBtc();
            snippets.GenerateAddressEth();
            snippets.GenerateAddressBch();
            snippets.GenerateAddressLtc();
            snippets.GenerateAddressDoge();
            snippets.GenerateAddressDash();

            snippets.GetAddressTransactionsBtc();
            snippets.GetAddressTransactionsEth();
            snippets.GetAddressTransactionsBch();
            snippets.GetAddressTransactionsLtc();
            snippets.GetAddressTransactionsDoge();
            snippets.GetAddressTransactionsDash();

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
            var dogeAddresses = new[] { "D8UotBUco4bUUeVDyxW5H5FAeaeXxLoT2Q", "DUBQ1z7PPKh5UoV655s1dufZ3fM6sYZCV1" };
            snippets.AddAddressDoge(dogeWallet, dogeAddresses);
            snippets.GenerateAddressesDoge(dogeWallet);
            snippets.RemoveAddressesDoge(dogeWallet, dogeAddresses[0]);
            snippets.DeleteWalletDoge(dogeWallet);

            var dashWallet = snippets.CreateWalletDash();
            snippets.GetWalletsDash();
            snippets.GetWalletDash(dashWallet);
            var dashAddresses = new[] { "yfG7JxsY6Bx4XwqGNcQL4QX4CzKjQJ54dz", "yan1VFWPFhiVotNfygnuiDrA6xguioBgry" };
            snippets.AddAddressDash(dashWallet, dashAddresses);
            snippets.GenerateAddressesDash(dashWallet);
            snippets.RemoveAddressesDash(dashWallet, dashAddresses[0]);
            snippets.DeleteWalletDash(dashWallet);

            var btcHdWallet = snippets.CreateHdWalletBtc();
            snippets.GetHdWalletsBtc();
            snippets.GetHdWalletBtc(btcHdWallet);
            // snippets.AddHdBtcAddress(); todo: this is not implemented?
            snippets.GenerateHdAddressesBtc(btcHdWallet);
            // snippets.RemoveHdBtcAddresses(btcHdWallet, btcHdAddresses[0]); todo: this is not implemented?
            snippets.DeleteHdWalletBtc(btcHdWallet);

            var bchHdWallet = snippets.CreateHdWalletBch();
            snippets.GetHdWalletsBch();
            snippets.GetHdWalletBch(bchHdWallet);
            // snippets.AddHdBchAddress(); todo: this is not implemented?
            snippets.GenerateHdAddressesBch(bchHdWallet);
            // snippets.RemoveHdBchAddresses(bchHdWallet, bchHdAddresses[0]); todo: this is not implemented?
            snippets.DeleteHdWalletBch(bchHdWallet);

            var ltcHdWallet = snippets.CreateHdWalletLtc();
            snippets.GetHdWalletsLtc();
            snippets.GetHdWalletLtc(ltcHdWallet);
            // snippets.AddHdLtcAddress(); todo: this is not implemented?
            snippets.GenerateHdAddressesLtc(ltcHdWallet);
            // snippets.RemoveHdLtcAddresses(ltcHdWallet, ltcHdAddresses[0]); todo: this is not implemented?
            snippets.DeleteHdWalletLtc(ltcHdWallet);

            var dogeHdWallet = snippets.CreateHdWalletDoge();
            snippets.GetHdWalletsDoge();
            snippets.GetHdWalletDoge(dogeHdWallet);
            // snippets.AddHdDogeAddress(); todo: this is not implemented?
            snippets.GenerateHdAddressesDoge(dogeHdWallet);
            // snippets.RemoveHdDogeAddresses(dogeHdWallet, dogeHdAddresses[0]); todo: this is not implemented?
            snippets.DeleteHdWalletDoge(dogeHdWallet);

            var dashHdWallet = snippets.CreateHdWalletDash();
            snippets.GetHdWalletsDash();
            snippets.GetHdWalletDash(dashHdWallet);
            // snippets.AddHdDashAddress(); todo: this is not implemented?
            snippets.GenerateHdAddressesDash(dashHdWallet);
            // snippets.RemoveHdDashAddresses(dashHdWallet, dashHdAddresses[0]); todo: this is not implemented?
            snippets.DeleteHdWalletDash(dashHdWallet);
        }

        private static void RunTransactionBlockchainsFeatures(BlockchainSnippets snippets)
        {
            snippets.GetInfoByTransactionHashEth();
            snippets.GetInfoByTransactionIdBtc();
            snippets.GetInfoByTransactionIdBch();
            snippets.GetInfoByTransactionIdLtc();
            snippets.GetInfoByTransactionIdDoge();
            snippets.GetInfoByTransactionIdDash();

            snippets.GetInfoByBlockHashAndTransactionIndex();
            snippets.GetInfoByBlockHeightAndTransactionIndex();

            snippets.GetInfosByBlockHeightBtc();
            snippets.GetInfosByBlockHeightEth();
            snippets.GetInfosByBlockHeightBch();
            snippets.GetInfosByBlockHeightLtc();
            snippets.GetInfosByBlockHeightDoge();
            snippets.GetInfosByBlockHeightDash();

            snippets.GetInfosByBlockHashBtc();
            snippets.GetInfosByBlockHashBch();
            snippets.GetInfosByBlockHashLtc();
            snippets.GetInfosByBlockHashDoge();
            snippets.GetInfosByBlockHashDash();

            snippets.GetUnconfirmedTransactionsBtc();
            snippets.GetUnconfirmedTransactionsBch();
            snippets.GetUnconfirmedTransactionsLtc();
            snippets.GetUnconfirmedTransactionsDoge();
            snippets.GetUnconfirmedTransactionsDash();

            snippets.CreateTransactionBtc();
            snippets.CreateTransactionBch();
            snippets.CreateTransactionLtc();
            snippets.CreateTransactionDoge();
            snippets.CreateTransactionDash();

            snippets.CreateTransactionUsingPassword();
            snippets.CreateTransactionUsingPrivateKey();

            snippets.SendAllAmountUsingPassword();
            snippets.SendAllAmountUsingPrivateKey();

            snippets.SendTransactionBtc();
            snippets.SendTransactionBch();
            snippets.SendTransactionLtc();
            snippets.SendTransactionDoge();
            snippets.SendTransactionDash();

            snippets.LocallySignTransaction();

            snippets.NewTransactionBtc();
            snippets.NewTransactionBch();
            snippets.NewTransactionLtc();
            snippets.NewTransactionDoge();
            snippets.NewTransactionDash();

            snippets.NewHdTransactionBtc();
            snippets.NewHdTransactionBch();
            snippets.NewHdTransactionLtc();
            snippets.NewHdTransactionDoge();
            snippets.NewHdTransactionDash();

            snippets.PushTransaction();
            snippets.EstimateTransactionGas();
            snippets.PendingTransactions();
            snippets.QueuedTransactions();

            snippets.DecodeTransactionBtc();
            snippets.DecodeTransactionBch();
            snippets.DecodeTransactionLtc();
            snippets.DecodeTransactionDoge();
            snippets.DecodeTransactionDash();

            snippets.TransactionsFeeBtc();
            snippets.TransactionsFeeEth();
            snippets.TransactionsFeeBch();
            snippets.TransactionsFeeLtc();
            snippets.TransactionsFeeDoge();
            snippets.TransactionsFeeDash();

            snippets.SignTransactionBtc();
            snippets.SignTransactionBch();
            snippets.SignTransactionLtc();
            snippets.SignTransactionDoge();
            snippets.SignTransactionDash();
        }

        private static void RunPaymentForwardingBlockchainsFeatures(BlockchainSnippets snippets)
        {
            var btcPaymentId = snippets.CreatePaymentBtc();
            var ethPaymentId = snippets.CreatePaymentEth();
            var bchPaymentId = snippets.CreatePaymentBch();
            var ltcPaymentId = snippets.CreatePaymentLtc();
            var dogePaymentId = snippets.CreatePaymentDoge();
            var dashPaymentId = snippets.CreatePaymentDash();

            snippets.GetPaymentsBtc();
            snippets.GetPaymentsEth();
            snippets.GetPaymentsBch();
            snippets.GetPaymentsLtc();
            snippets.GetPaymentsDoge();
            snippets.GetPaymentsDash();

            snippets.GetHistoricalPaymentsBtc();
            snippets.GetHistoricalPaymentsEth();
            snippets.GetHistoricalPaymentsBch();
            snippets.GetHistoricalPaymentsLtc();
            snippets.GetHistoricalPaymentsDoge();
            snippets.GetHistoricalPaymentsDash();

            snippets.DeletePaymentBtc(btcPaymentId);
            snippets.DeletePaymentEth(ethPaymentId);
            snippets.DeletePaymentBch(bchPaymentId);
            snippets.DeletePaymentLtc(ltcPaymentId);
            snippets.DeletePaymentDoge(dogePaymentId);
            snippets.DeletePaymentDash(dashPaymentId);
        }

        private static void RunWebhookNotificationBlockchainsFeatures(BlockchainSnippets snippets)
        {
            snippets.CreateNewBlockBtc();
            snippets.CreateNewBlockEth();
            snippets.CreateNewBlockBch();
            snippets.CreateNewBlockLtc();
            snippets.CreateNewBlockDoge();
            snippets.CreateNewBlockDash();

            snippets.CreateConfirmedTransactionBtc();
            snippets.CreateConfirmedTransactionEth();
            snippets.CreateConfirmedTransactionBch();
            snippets.CreateConfirmedTransactionLtc();
            snippets.CreateConfirmedTransactionDoge();
            snippets.CreateConfirmedTransactionDash();

            var btcHookId = snippets.CreateAddressBtc();
            var ethHookId = snippets.CreateAddressEth();
            var bchHookId = snippets.CreateAddressBch();
            var ltcHookId = snippets.CreateAddressLtc();
            var dogeHookId = snippets.CreateAddressDoge();
            var dashHookId = snippets.CreateAddressDash();

            snippets.CreateToken();
            snippets.CreateTransactionPool();

            snippets.GetHooksBtc();
            snippets.GetHooksEth();
            snippets.GetHooksBch();
            snippets.GetHooksLtc();
            snippets.GetHooksDoge();
            snippets.GetHooksDash();

            snippets.DeleteHookBtc(btcHookId);
            snippets.DeleteHookEth(ethHookId);
            snippets.DeleteHookBch(bchHookId);
            snippets.DeleteHookLtc(ltcHookId);
            snippets.DeleteHookDoge(dogeHookId);
            snippets.DeleteHookDash(dashHookId);
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