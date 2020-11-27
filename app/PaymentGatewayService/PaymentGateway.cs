﻿//-----------------------------------------------------------------------------------------------------------
// <copyright file="PaymentGateway.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService
{
    using app.Controllers;
    using app.PaymentGatewayService.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


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
        public static async Task<IActionResult> ProcessPayment(PaymentDetailsPayload payload)
        {
            try
            {
                // check with bank

                // create new object
                PaymentDetails paymentDetails = new PaymentDetails().Map(payload, true);

                // save in database

                // return response
                return new OkObjectResult(new PaymentDetailsResponse().Map(paymentDetails));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

    }
}
