using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications
{
    [TestClass]
    public abstract class BtcSimilarCoin : BaseTest
    {
        protected void AssertHook(NetworkCoin networkCoin, string hookId)
        {
            var getHookResponse = Manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(networkCoin);
            AssertNullErrorMessage(getHookResponse);
            AssertNotEmptyCollection(nameof(getHookResponse.Hooks), getHookResponse.Hooks);
            Assert.IsNotNull(getHookResponse.Hooks.FirstOrDefault(h => h.Id.Equals(hookId, StringComparison.OrdinalIgnoreCase)));
        }
    }
}