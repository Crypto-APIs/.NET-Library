using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.PaymentForwardings.DeletePayment
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.PaymentForwarding.GetPayments<GetBtcPaymentsResponse>(networkCoin);
            AssertNullErrorMessage(response);

            foreach (var payment in response.Payments)
            {
                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(
                    networkCoin, payment.Id);
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message),
                    $"'{nameof(deleteResponse.Payload.Message)}' must not be null");
                Assert.AreEqual($"Payment Forwarding with uuid {payment.Id} was successfully deleted",
                    deleteResponse.Payload.Message, "'Message' is wrong");
            }
            
            var secondResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetBtcPaymentsResponse>(networkCoin);
            AssertNullErrorMessage(secondResponse);
            AssertEmptyCollection(nameof(secondResponse.Payments), secondResponse.Payments);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A PaymentId of null was inappropriately allowed.")]
        public void NullPaymentId_Exception(NetworkCoin networkCoin)
        {
            string paymentId = null;

            Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(networkCoin, paymentId);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidPaymentId_Exception(NetworkCoin networkCoin)
        {
            var paymentId = "qw'e";

            var response = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(networkCoin, paymentId);

            AssertErrorMessage(response, IsAdditionalPackagePlan
                ? "Payment Forwarding not found"
                : "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
        }
    }
}