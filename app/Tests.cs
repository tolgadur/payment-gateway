//-----------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------



namespace app.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using app.Controllers;
    using app.PaymentGatewayService;
    using app.PaymentGatewayService.Models;
    using Newtonsoft.Json.Linq;
    using Xunit;

    /// <summary>
    /// Defines the <see cref="Tests" />.
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// The test id for test purposes.
        /// </summary>
        private static string testId = "822f4b34-c3a9-4cf3-9194-9a26b12770ee";

        /// <summary>
        /// Tests the activity creation.
        /// </summary>
        [Fact]
        public static void TestGetPaymentDetails()
        {
            try
            {
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
                Assert.Equal(testId, result.Id);
                Assert.Equal(352, result.Amount);
                Assert.Equal("TestNumber", result.CardNumber);
                Assert.Equal("EUR", result.Currency);
                Assert.Equal("1", result.Cvv);
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
        /// Tests the activity creation.
        /// </summary>
        [Fact]
        public static void TestSetMerchantDetails()
        {
            try
            {
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
                Assert.Equal(testId, result.Id);
                Assert.Equal("Test", result.Name);
                Assert.Equal("12345", result.CardNumber);
                Assert.Equal("1", result.Cvv);
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

    }
}
