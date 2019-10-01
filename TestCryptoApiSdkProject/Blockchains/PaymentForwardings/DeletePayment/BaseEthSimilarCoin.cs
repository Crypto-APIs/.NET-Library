using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Blockchains.PaymentForwardings.DeletePayment
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.PaymentForwarding.GetPayments<GetEthPaymentsResponse>(NetworkCoin);
            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            foreach (var payment in response.Payments)
            {
                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteEthPaymentResponse>(NetworkCoin, payment.Id);
                Assert.IsNotNull(deleteResponse);
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message));
                Assert.AreEqual($"Payment forwarding with uuid : {payment.Id} was successfully deleted!", deleteResponse.Payload.Message);
            }

            var secondResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetEthPaymentsResponse>(NetworkCoin);
            Assert.IsNotNull(secondResponse);
            Assert.IsTrue(string.IsNullOrEmpty(secondResponse.ErrorMessage));
            Assert.IsFalse(secondResponse.Payments.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A PaymentId of null was inappropriately allowed.")]
        public void NullPaymentId()
        {
            string paymentId = null;
            Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteEthPaymentResponse>(NetworkCoin, paymentId);
        }

        [TestMethod]
        public void InvalidPaymentId()
        {
            var paymentId = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteEthPaymentResponse>(NetworkCoin, paymentId);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual($"Could not delete payment forwarding with uuid: {paymentId}", response.ErrorMessage);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}