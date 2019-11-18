using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.PaymentForwardings.DeletePayment
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.PaymentForwarding.GetPayments<GetEthPaymentsResponse>(networkCoin);
            AssertNullErrorMessage(response);

            foreach (var payment in response.Payments)
            {
                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteEthPaymentResponse>(
                    networkCoin, payment.Id);
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message),
                    $"'{nameof(deleteResponse.Payload.Message)}' must not be null");
                Assert.AreEqual($"Payment forwarding with uuid : {payment.Id} was successfully deleted!",
                    deleteResponse.Payload.Message, "'Message' is wrong");
            }

            var secondResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetEthPaymentsResponse>(networkCoin);
            AssertNullErrorMessage(secondResponse);
            AssertEmptyCollection(nameof(secondResponse.Payments), secondResponse.Payments);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A PaymentId of null was inappropriately allowed.")]
        public void NullPaymentId_Exception(NetworkCoin networkCoin)
        {
            string paymentId = null;

            Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteEthPaymentResponse>(networkCoin, paymentId);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidPaymentId_Exception(NetworkCoin networkCoin)
        {
            var paymentId = "qw'e";

            var response = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteEthPaymentResponse>(networkCoin, paymentId);

            AssertErrorMessage(response, IsAdditionalPackagePlan
                ? $"Could not delete payment forwarding with uuid: {paymentId}"
                : "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
        }
    }
}