using CryptoApisSdkLibrary;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestCryptoApiSdk
{
    [TestClass]
    public abstract class BaseTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public virtual void TestInitialize()
        {
            ProxyCredentialsFilenameProvider = new GetFilenameProvider(new[]
            {
                @"E:\Igor\Third\Credentials.txt",
            });
            AccountCredentialsFilenameProvider = new GetFilenameProvider(new[]
            {
                @"..\..\..\Credentials\AccountCredentials.txt",
                @"..\..\AccountCredentials.txt",
                @"E:\Igor\Third\AccountCredentials.txt",
                @"E:\Work\CryptoApisSdkLibrary\Credentials\AccountCredentials.txt"
            });
            ApiKeyFilenameProvider = new GetFilenameProvider(new[]
            {
                @"..\..\..\Credentials\ApiKey.txt",
                @"..\..\ApiKey.txt",
                @"E:\Igor\Third\ApiKey.txt",
                @"e:\Work\CryptoApisSdkLibrary\Credentials\ApiKey.txt"
            });

            var apiKey = LoadApiKey();
            var credentials = LoadCredentials();
            AccountPassword = LoadAccountPassword();

            Manager = new CryptoManager(apiKey, credentials);
            Manager.SetResponseRequestLogger(new ResponseRequestLogger(TestContext));

            BeforeTest();
        }

        protected virtual void BeforeTest()
        {
        }

        protected void AssertNotNullResponse(BaseResponse response)
        {
            Assert.IsNotNull(response, $"'{nameof(response)}' must not be null");
        }

        protected void AssertNullErrorMessage(BaseResponse response)
        {
            AssertNotNullResponse(response);
            Assert.IsTrue(
                string.IsNullOrEmpty(response.ErrorMessage),
                $"'{nameof(response.ErrorMessage)}' must be null");
        }

        protected void AssertEmptyCollection(string collectionName, IEnumerable<object> collection)
        {
            Assert.IsNotNull(collection, $"'{collectionName}' must not be null");
            Assert.IsFalse(collection.Any(), "Collection must be empty");
        }

        protected void AssertNotEmptyCollection(string collectionName, IEnumerable<object> collection)
        {
            Assert.IsNotNull(collection, $"'{collectionName}' must not be null");
            Assert.IsTrue(collection.Any(), "Collection must not be empty");
        }

        protected void AssertErrorMessage(BaseResponse response, string etalonErrorMessage)
        {
            AssertNotNullResponse(response);
            Assert.IsFalse(
                string.IsNullOrEmpty(response.ErrorMessage),
                $"'{nameof(response.ErrorMessage)}' must not be null");
            Assert.AreEqual(etalonErrorMessage, response.ErrorMessage);
        }

        private ProxyCredentials LoadCredentials()
        {
            ProxyCredentials credentials = null;
            var filename = ProxyCredentialsFilenameProvider.Filename;
            if (File.Exists(filename))
            {
                var reader = new StreamReader(File.OpenRead(filename));
                //var reader = new StreamReader(File.OpenRead(filename), Encoding.GetEncoding(1251));
                var fileContent = new List<string>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    fileContent.Add(line);
                }

                credentials = new ProxyCredentials(
                    host: fileContent[0], port: int.Parse(fileContent[1]),
                    username: fileContent[2], password: fileContent[3], domain: fileContent[4]);
            }
            return credentials;
        }

        private string LoadAccountPassword()
        {
            var filename = AccountCredentialsFilenameProvider.Filename;
            if (!File.Exists(filename))
                return null;

            var reader = new StreamReader(File.OpenRead(filename));
            //var reader = new StreamReader(File.OpenRead(filename), Encoding.GetEncoding(1251));
            var fileContent = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                fileContent.Add(line);
            }

            return fileContent[0];
        }

        protected virtual string LoadApiKey()
        {
            var apiKeyFilename = ApiKeyFilenameProvider.Filename;
            if (!File.Exists(apiKeyFilename))
                throw new FileNotFoundException($"File with api key \"{apiKeyFilename}\" not found");

            var reader = new StreamReader(File.OpenRead(apiKeyFilename));
            //var reader = new StreamReader(File.OpenRead(apiKeyFilename), Encoding.GetEncoding(1251));
            return reader.ReadLine();
        }

        protected CryptoManager Manager { get; private set; }
        protected readonly bool IsAdditionalPackagePlan = true;
        protected string AccountPassword { get; private set; }

        private IFilenameProvider ProxyCredentialsFilenameProvider { get; set; }
        private IFilenameProvider ApiKeyFilenameProvider { get; set; }
        private IFilenameProvider AccountCredentialsFilenameProvider { get; set; }
    }
}