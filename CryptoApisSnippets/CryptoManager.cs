using System.Collections.Generic;
using System.IO;
using System.Text;
using CryptoApisLibrary.Misc;

namespace CryptoApisSnippets
{
    /// <summary>
    /// Facade for CryptoApisSdkLibrary.CryptoManager
    /// </summary>
    internal class CryptoManager : CryptoApisLibrary.CryptoManager
    {
        public CryptoManager(string apiKey) : base(apiKey, LoadCredentials())
        {
        }

        private static ProxyCredentials LoadCredentials()
        {
            const string filename = "e:\\credentials.txt";
            if (!File.Exists(filename))
                return null;

            var reader = new StreamReader(File.OpenRead(filename), Encoding.GetEncoding(1251));
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