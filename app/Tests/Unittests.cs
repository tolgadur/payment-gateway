//-----------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------



namespace app.Tests
{
    using System;
    using System.Diagnostics;
    using app.Controllers;
    using app.PaymentGatewayService;
    using app.PaymentGatewayService.Models;
    using Microsoft.Extensions.Configuration;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="Unittests" />.
    /// </summary>
    [TestFixture]
    public class Unittests
    {
        /// <summary>
        /// The test id for test purposes.
        /// </summary>
        private static string testId = "test-id";

        /// <summary>
        /// Tests the activity creation.
        /// </summary>
        [Test]
        public static void TestGetPaymentDetails()
        {
            try
            {
                SetupAppsettingsConfiguration();

                // set payment details
                var paymentDetails = new PaymentDetails()
                {
                    Id = testId,
                    Amount = 352,
                    CardNumber = "TestNumber",
                    Currency = "EUR",
                    Reference = "",
                    Cvv = "1",
                    Success = false,
                    ExpiryDate = DateTime.Now,
                };
                ConnectionHelper.SavePayment(paymentDetails);

                // get payment details 
                var result = ConnectionHelper.GetPaymentById(testId);
                Assert.AreEqual(testId, result.Id);
                Assert.AreEqual(352, result.Amount);
                Assert.AreEqual("TestNumber", result.CardNumber);
                Assert.AreEqual("EUR", result.Currency);
                Assert.AreEqual("1", result.Cvv);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                ConnectionHelper.DeletePaymentById(testId);
            }
        }

        /// <summary>
        /// Tests the activity creation.
        /// </summary>
        [Test]
        public static void TestSetMerchantDetails()
        {
            try
            {
                SetupAppsettingsConfiguration();

                // set merchant details
                var merchantDetails = new MerchantDetails()
                {
                    Id = testId,
                    Name = "Test",
                    CardNumber = "12345",
                    Cvv = "1"
                };
                ConnectionHelper.SaveMerchantDetails(merchantDetails);

                // get merchant details 
                var result = ConnectionHelper.GetMerchantById(testId);
                Assert.AreEqual(testId, result.Id);
                Assert.AreEqual("Test", result.Name);
                Assert.AreEqual("12345", result.CardNumber);
                Assert.AreEqual("1", result.Cvv);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                ConnectionHelper.DeleteMerchantById(testId);
            }
        }

        /// <summary>
        /// Sets up the configuration file necced from the connectionhelper 
        /// </summary>
        private static void SetupAppsettingsConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            ConnectionHelper.Init(configuration);
        }

    }
}
