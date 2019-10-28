using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptoApisLibrary;
using CryptoApisLibrary.Misc;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var proxyCredentialsFilenameProvider = new GetFilenameProvider(new[]
            {
                @"E:\Igor\Third\Credentials.txt",
            });
            var apiKeyFilenameProvider = new GetFilenameProvider(new[]
            {
                @"..\..\..\Credentials\ApiKey.txt",
                @"..\..\ApiKey.txt",
                @"E:\Igor\Third\ApiKey.txt",
                @"e:\Work\CryptoApisSdkLibrary\Credentials\ApiKey.txt"
            });

            var apiKey = LoadApiKey(apiKeyFilenameProvider);
            var credentials = LoadCredentials(proxyCredentialsFilenameProvider);

            var manager = new CryptoManager(apiKey, credentials);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(manager));


        }
        private static string LoadApiKey(IFilenameProvider filenameProvider)
        {
            var apiKeyFilename = filenameProvider.Filename;
            if (!File.Exists(apiKeyFilename))
                throw new FileNotFoundException($"File with api key \"{apiKeyFilename}\" not found");

            using (var reader = new StreamReader(File.OpenRead(apiKeyFilename)))
            {
                return reader.ReadLine();
            }
        }

        private static ProxyCredentials LoadCredentials(IFilenameProvider filenameProvider)
        {
            var filename = filenameProvider.Filename;
            if (!File.Exists(filename))
                return null;

            var reader = new StreamReader(File.OpenRead(filename));
            var fileContent = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                fileContent.Add(line);
            }

            return new ProxyCredentials(
                host: fileContent[0], port: int.Parse(fileContent[1]),
                username: fileContent[2], password: fileContent[3], domain: fileContent[4]);
        }
    }
}
