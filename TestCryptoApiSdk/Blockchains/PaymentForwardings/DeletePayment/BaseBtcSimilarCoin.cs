using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.PaymentForwardings.DeletePayment
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.PaymentForwarding.GetPayments<GetBtcPaymentsResponse>(NetworkCoin);
            AssertNullErrorMessage(response);

            foreach (var payment in response.Payments)
            {
                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(
                    NetworkCoin, payment.Id);
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message),
                    $"'{nameof(deleteResponse.Payload.Message)}' must not be null");
                Assert.AreEqual($"Payment Forwarding with uuid {payment.Id} was successfully deleted", 
                    deleteResponse.Payload.Message, "'Message' is wrong");
            }

            var secondResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetBtcPaymentsResponse>(NetworkCoin);
            AssertNullErrorMessage(secondResponse);
            AssertEmptyCollection(nameof(secondResponse.Payments), secondResponse.Payments);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A PaymentId of null was inappropriately allowed.")]
        public void TestBtcDeleteNullPaymentId()
        {
            string paymentId = null;
            Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(NetworkCoin, paymentId);
        }

        [TestMethod]
        public void TestBtcDeleteInvalidPaymentId()
        {
            var paymentId = "qw'e";
            var response = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(NetworkCoin, paymentId);

            AssertErrorMessage(response, IsAdditionalPackagePlan
                ? "Payment Forwarding not found"
                : "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}