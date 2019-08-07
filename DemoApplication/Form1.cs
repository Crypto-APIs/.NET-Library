using CryptoApisSdkLibrary;
using CryptoApisSdkLibrary.Misc;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DemoApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var apiKey = LoadApiKey();
            _crypto = new CryptoManager(apiKey);
        }

        private void getAssetsButton_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            symbolListBox.Items.Clear();

            var response = _crypto.Exchanges.GetSymbols();
            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                foreach (var symbol in response.Symbols)
                {
                    symbolListBox.Items.Add(symbol);
                }

                statusStrip.Items.Add("Get Symbols successfully");
            }
            else
            {
                statusStrip.Items.Add($"Get Symbols error: {response.ErrorMessage}");
            }
        }

        private string LoadApiKey()
        {
            var apiKeyFilenameProvider = new GetFilenameProvider(new[]
            {
                @"..\..\..\Credentials\ApiKey.txt",
                @"..\..\ApiKey.txt",
                @"E:\Igor\Third\ApiKey.txt",
                @"e:\Work\CryptoApisSdkLibrary\Credentials\ApiKey.txt"
            });

            var apiKeyFilename = apiKeyFilenameProvider.Filename;
            if (!File.Exists(apiKeyFilename))
                throw new FileNotFoundException($"File with api key \"{apiKeyFilename}\" not found");

            var reader = new StreamReader(File.OpenRead(apiKeyFilename), Encoding.GetEncoding(1251));
            return reader.ReadLine();
        }

        private readonly ICryptoManager _crypto;
        private CancellationTokenSource _token;

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _token.Cancel();
        }

        private async void getExchangesButton_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            exchangeListBox.Items.Clear();

            _token = new CancellationTokenSource();
            try
            {
                var response = await _crypto.Exchanges.GetExchangesAsync(_token.Token);
                if (string.IsNullOrEmpty(response.ErrorMessage))
                {
                    foreach (var exchange in response.Exchanges)
                    {
                        exchangeListBox.Items.Add(exchange);
                    }

                    statusStrip.Items.Add("Get Exchanges successfully");
                }
                else
                {
                    statusStrip.Items.Add($"Get Exchanges error: {response.ErrorMessage}");
                }
            }
            catch (OperationCanceledException)
            {
                statusStrip.Items.Add($"Get Exchanges was canceled.");
            }
        }
    }
}