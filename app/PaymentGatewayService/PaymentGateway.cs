//-----------------------------------------------------------------------------------------------------------
// <copyright file="PaymentGateway.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SQLite;
    using System.Configuration;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using app.Controllers;
    using app.PaymentGatewayService.Models;
    using System.Data;
    using app.PaymentGatewayService.Models.ApiModels;


    /// <summary>
    /// Defines the <see cref="PaymentGateway" />.
    /// </summary>
    public class PaymentGateway
    {
        /// <summary>
        /// This endpoint will process the payment.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>
        /// The <see cref="Task{IActionResult}" />.
        /// </returns>
        public static IActionResult ProcessPayment(ProcessPaymentPayload payload, IBankRequest bankRequest)
        {
            try
            {
                // process payment with bank
                var merchantId = payload.MerchantIdentifier;
                var isPayout = payload.IsPayout;
                var merchant = ConnectionHelper.GetMerchantById(merchantId);
                var bankRequestPayload = new BankRequestPayload().Map(payload, merchant, isPayout);
                var bankResponse = (ProcessPaymentResponse) bankRequest.ProcessPayment(bankRequestPayload);

                // save in database
                PaymentDetails paymentDetails = new PaymentDetails().Map(payload, bankResponse.PaymentId, bankResponse.Success);
                ConnectionHelper.SavePayment(paymentDetails);

                // return response
                return new OkObjectResult(new ProcessPaymentResponse().Map(paymentDetails));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

        /// <summary>
        /// This endpoint will set the merchants details.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>
        /// The <see cref="Task{IActionResult}" />.
        /// </returns>
        public static IActionResult SetMerchantDetails(SetMerchantDetailsPayload payload)
        {
            try
            {
                // save in database
                MerchantDetails merchantDetails = new MerchantDetails().Map(payload);
                ConnectionHelper.SaveMerchantDetails(merchantDetails);

                // return response
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}
