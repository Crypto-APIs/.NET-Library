﻿using CryptoApisLibrary.Misc;
using CryptoApisLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisLibrary.Tests
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

        protected void AssertNotNullResponse(IResponse response)
        {
            Assert.IsNotNull(response, $"'{nameof(response)}' must not be null");
        }

        protected void AssertNullErrorMessage(IResponse response)
        {
            AssertNotNullResponse(response);
            Assert.IsTrue(
                string.IsNullOrEmpty(response.ErrorMessage),
                $"'{nameof(response.ErrorMessage)}' must be null, but is was '{response.ErrorMessage}'");
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

        protected void AssertErrorMessage(IResponse response, string etalonErrorMessage)
        {
            AssertNotNullResponse(response);
            Assert.IsFalse(
                string.IsNullOrEmpty(response.ErrorMessage),
                $"'{nameof(response.ErrorMessage)}' must not be null");
            Assert.AreEqual(etalonErrorMessage, response.ErrorMessage, "'ErrorMessage' is wrong");
        }

        protected void AssertErrorMessagePart(IResponse response, string etalonErrorMessage)
        {
            AssertNotNullResponse(response);
            Assert.IsFalse(
                string.IsNullOrEmpty(response.ErrorMessage),
                $"'{nameof(response.ErrorMessage)}' must not be null");
            Assert.IsTrue(response.ErrorMessage.Contains(etalonErrorMessage), "'ErrorMessage' is wrong");
        }

        protected bool AssertAdditionalPackagePlan(IResponse response)
        {
            if (!IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response,
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }

            return IsAdditionalPackagePlan;
        }

        private ProxyCredentials LoadCredentials()
        {
            var filename = ProxyCredentialsFilenameProvider.Filename;
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

        private string LoadAccountPassword()
        {
            var filename = AccountCredentialsFilenameProvider.Filename;
            if (!File.Exists(filename))
                return null;

            using (var reader = new StreamReader(File.OpenRead(filename)))
            {
                var fileContent = new List<string>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    fileContent.Add(line);
                }

                return fileContent[0];
            }
        }

        protected virtual string LoadApiKey()
        {
            var apiKeyFilename = ApiKeyFilenameProvider.Filename;
            if (!File.Exists(apiKeyFilename))
                throw new FileNotFoundException($"File with api key \"{apiKeyFilename}\" not found");

            using (var reader = new StreamReader(File.OpenRead(apiKeyFilename)))
            {
                return reader.ReadLine();
            }
        }

        protected CryptoManager Manager { get; private set; }
        protected readonly bool IsAdditionalPackagePlan = true;
        protected string AccountPassword { get; private set; }

        private IFilenameProvider ProxyCredentialsFilenameProvider { get; set; }
        private IFilenameProvider ApiKeyFilenameProvider { get; set; }
        private IFilenameProvider AccountCredentialsFilenameProvider { get; set; }
    }
}