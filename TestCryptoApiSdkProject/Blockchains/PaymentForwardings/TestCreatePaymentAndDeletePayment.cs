using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.PaymentForwardings
{
    [TestClass]
    public class TestCreateAddressAndDeleteHook : BaseTest
    {
        [TestMethod]
        public void TestBtcMain()
        {
            var fromAddress = "1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9";
            var toAddress = "1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(response.Id));

                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment(
                    BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet, response.Id);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Status));
                Assert.AreEqual("ok", deleteResponse.Status);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestBtcTest()
        {
            var fromAddress = "1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9";
            var toAddress = "1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(response.Id));

                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment(
                    BtcSimilarCoin.Btc, BtcSimilarNetwork.Testnet, response.Id);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Status));
                Assert.AreEqual("ok", deleteResponse.Status);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestBchMain()
        {
            var fromAddress = "1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9";
            var toAddress = "1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Mainnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(response.Id));

                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment(
                    BtcSimilarCoin.Bch, BtcSimilarNetwork.Mainnet, response.Id);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Status));
                Assert.AreEqual("ok", deleteResponse.Status);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestBchTest()
        {
            var fromAddress = "1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9";
            var toAddress = "1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(response.Id));

                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment(
                    BtcSimilarCoin.Bch, BtcSimilarNetwork.Testnet, response.Id);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Status));
                Assert.AreEqual("ok", deleteResponse.Status);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestLtcMain()
        {
            var fromAddress = "1P3t6SKHuymgrs2vvgFvtsmnKen2C8gKU9";
            var toAddress = "1K2huCLxy9tXWc5Yn8ow6vqPGvTaCXHo5q";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Mainnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(response.Id));

                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment(
                    BtcSimilarCoin.Ltc, BtcSimilarNetwork.Mainnet, response.Id);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Status));
                Assert.AreEqual("ok", deleteResponse.Status);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestLtcTest()
        {
            var fromAddress = "LNBscCs43tU61X1NmoqGySPyRBpoFMwwvy";
            var toAddress = "LXAWGfYhFEqfW8oTQ9Ebj7yX4qP6gK1b4K";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(response.Id));

                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment(
                    BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, response.Id);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Status));
                Assert.AreEqual("ok", deleteResponse.Status);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void TestBtcNullFromAddress()
        {
            string fromAddress = null;
            var toAddress = "LXAWGfYhFEqfW8oTQ9Ebj7yX4qP6gK1b4K";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void TestBtcNullToAddress()
        {
            var fromAddress = "LNBscCs43tU61X1NmoqGySPyRBpoFMwwvy";
            string toAddress = null;
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A CallbackUrl of null was inappropriately allowed.")]
        public void TestBtcNullCallbackUrl()
        {
            var fromAddress = "LNBscCs43tU61X1NmoqGySPyRBpoFMwwvy";
            var toAddress = "LXAWGfYhFEqfW8oTQ9Ebj7yX4qP6gK1b4K";
            string callbackUrl = null;
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Wallet of null was inappropriately allowed.")]
        public void TestBtcNullWallet()
        {
            var fromAddress = "LNBscCs43tU61X1NmoqGySPyRBpoFMwwvy";
            var toAddress = "LXAWGfYhFEqfW8oTQ9Ebj7yX4qP6gK1b4K";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            string wallet = null;
            var password = "SECRET123456";
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void TestBtcNullPassword()
        {
            var fromAddress = "LNBscCs43tU61X1NmoqGySPyRBpoFMwwvy";
            var toAddress = "LXAWGfYhFEqfW8oTQ9Ebj7yX4qP6gK1b4K";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            string password = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);
        }

        [TestMethod]
        public void TestBtcInvalidFromAddress()
        {
            var fromAddress = "qwe";
            var toAddress = "LXAWGfYhFEqfW8oTQ9Ebj7yX4qP6gK1b4K";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestBtcInvalidToAddress()
        {
            var fromAddress = "LNBscCs43tU61X1NmoqGySPyRBpoFMwwvy";
            var toAddress = "qwe";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestBtcInvalidCallbackUrl()
        {
            var fromAddress = "LNBscCs43tU61X1NmoqGySPyRBpoFMwwvy";
            var toAddress = "LXAWGfYhFEqfW8oTQ9Ebj7yX4qP6gK1b4K";
            var callbackUrl = "qwe";
            var wallet = "demohdwallet";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestBtcInvalidWallet()
        {
            var fromAddress = "LNBscCs43tU61X1NmoqGySPyRBpoFMwwvy";
            var toAddress = "LXAWGfYhFEqfW8oTQ9Ebj7yX4qP6gK1b4K";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "qwe";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestBtcInvalidPassword()
        {
            var fromAddress = "LNBscCs43tU61X1NmoqGySPyRBpoFMwwvy";
            var toAddress = "LXAWGfYhFEqfW8oTQ9Ebj7yX4qP6gK1b4K";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "demohdwallet";
            var password = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, fromAddress, toAddress, callbackUrl, wallet, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A PaymentId of null was inappropriately allowed.")]
        public void TestBtcDeleteNullPaymentId()
        {
            string paymentId = null;
            Manager.Blockchains.PaymentForwarding.DeletePayment(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet, paymentId);
        }

        [TestMethod]
        public void TestBtcDeleteInvalidPaymentId()
        {
            var paymentId = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.DeletePayment(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet, paymentId);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestEthMain()
        {
            var fromAddress = "0x195831d0fa4888c3fd577110d23ee464265c551a";
            var toAddress = "0x12b1883c01377f45ee5d7448a32b5ac1709af076";
            var callbackUrl = "http://somepoint.point";
            var password = "123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Mainnet, fromAddress, toAddress, callbackUrl, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(response.Id));

                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment(
                    EthSimilarCoin.Eth, EthSimilarNetwork.Mainnet, response.Id);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Success));
                Assert.AreEqual($"Payment forwarding with uuid: {response.Id} was successfully deleted!", deleteResponse.Success);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestEthRopsten()
        {
            var fromAddress = "0x195831d0fa4888c3fd577110d23ee464265c551a";
            var toAddress = "0x12b1883c01377f45ee5d7448a32b5ac1709af076";
            var callbackUrl = "http://somepoint.point";
            var password = "123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Ropsten, fromAddress, toAddress, callbackUrl, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(response.Id));

                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment(
                    EthSimilarCoin.Eth, EthSimilarNetwork.Ropsten, response.Id);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Success));
                Assert.AreEqual($"Payment forwarding with uuid: {response.Id} was successfully deleted!", deleteResponse.Success);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestEthRinkeby()
        {
            var fromAddress = "0x195831d0fa4888c3fd577110d23ee464265c551a";
            var toAddress = "0x12b1883c01377f45ee5d7448a32b5ac1709af076";
            var callbackUrl = "http://somepoint.point";
            var password = "123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Rinkeby, fromAddress, toAddress, callbackUrl, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(response.Id));

                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment(
                    EthSimilarCoin.Eth, EthSimilarNetwork.Rinkeby, response.Id);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Success));
                Assert.AreEqual($"Payment forwarding with uuid: {response.Id} was successfully deleted!", deleteResponse.Success);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void TestEthNullFromAddress()
        {
            string fromAddress = null;
            var toAddress = "0x12b1883c01377f45ee5d7448a32b5ac1709af076";
            var callbackUrl = "http://somepoint.point";
            var password = "123456";
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Rinkeby, fromAddress, toAddress, callbackUrl, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void TestEthNullToAddress()
        {
            var fromAddress = "0x195831d0fa4888c3fd577110d23ee464265c551a";
            string toAddress = null;
            var callbackUrl = "http://somepoint.point";
            var password = "123456";
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Rinkeby, fromAddress, toAddress, callbackUrl, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A CallbackUrl of null was inappropriately allowed.")]
        public void TestEthNullCallbackUrl()
        {
            var fromAddress = "0x195831d0fa4888c3fd577110d23ee464265c551a";
            var toAddress = "0x12b1883c01377f45ee5d7448a32b5ac1709af076";
            string callbackUrl = null;
            var password = "123456";
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Rinkeby, fromAddress, toAddress, callbackUrl, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void TestEthNullPassword()
        {
            var fromAddress = "0x195831d0fa4888c3fd577110d23ee464265c551a";
            var toAddress = "0x12b1883c01377f45ee5d7448a32b5ac1709af076";
            var callbackUrl = "http://somepoint.point";
            string password = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Rinkeby, fromAddress, toAddress, callbackUrl, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A PaymentId of null was inappropriately allowed.")]
        public void TestEthDeleteNullHookId()
        {
            string paymentId = null;
            Manager.Blockchains.PaymentForwarding.DeletePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Rinkeby, paymentId);
        }

        [TestMethod]
        public void TestEthDeleteInvalidHookId()
        {
            var paymentId = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.DeletePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Mainnet, paymentId);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestEthInvalidFromAddress()
        {
            var fromAddress = "qwe";
            var toAddress = "0x12b1883c01377f45ee5d7448a32b5ac1709af076";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Mainnet, fromAddress, toAddress, callbackUrl, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestEthInvalidToAddress()
        {
            var fromAddress = "0x195831d0fa4888c3fd577110d23ee464265c551a";
            var toAddress = "qwe";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Mainnet, fromAddress, toAddress, callbackUrl, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestEthInvalidCallbackUrl()
        {
            var fromAddress = "0x195831d0fa4888c3fd577110d23ee464265c551a";
            var toAddress = "0x12b1883c01377f45ee5d7448a32b5ac1709af076";
            var callbackUrl = "qwe";
            var password = "SECRET123456";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Mainnet, fromAddress, toAddress, callbackUrl, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestEthInvalidPassword()
        {
            var fromAddress = "0x195831d0fa4888c3fd577110d23ee464265c551a";
            var toAddress = "0x12b1883c01377f45ee5d7448a32b5ac1709af076";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var password = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment(
                EthSimilarCoin.Eth, EthSimilarNetwork.Mainnet, fromAddress, toAddress, callbackUrl, password);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("", response.ErrorMessage); //todo: corrected error message
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }
    }
}