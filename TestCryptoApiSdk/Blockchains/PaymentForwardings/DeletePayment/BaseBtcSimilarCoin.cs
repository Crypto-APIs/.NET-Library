﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);

            foreach (var payment in response.Payments)
            {
                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(NetworkCoin, payment.Id);
                AssertNotNullResponse(deleteResponse);
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message));
                Assert.AreEqual($"Payment Forwarding with uuid {payment.Id} was successfully deleted", deleteResponse.Payload.Message);
            }

            var secondResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetBtcPaymentsResponse>(NetworkCoin);
            AssertNotNullResponse(secondResponse);
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
            var paymentId = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(NetworkCoin, paymentId);

            AssertNotNullResponse(response);
            if (IsAdditionalPackagePlan)
            {
                AssertErrorMessage(response, "Payment Forwarding not found");
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}