//-----------------------------------------------------------------------------------------------------------
// <copyright file="IBankRequestTest.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService
{
    using app.PaymentGatewayService.Models;
    using app.PaymentGatewayService.Models.ApiModels;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using System;

    /// <summary>
    /// Defines the <see cref="BankRequestMock" />.
    /// </summary>
    public class BankRequestMock : IBankRequest
    {
        /// <summary>
        /// Returns exemplary api response of bank.
        /// </summary>
        ProcessPaymentResponse IBankRequest.ProcessPayment(BankRequestPayload content)
        {
            var paymentResponse = new ProcessPaymentResponse();
            paymentResponse.PaymentId = Guid.NewGuid().ToString();
            paymentResponse.Success = true;

            return paymentResponse;

        }

        /// <summary>
        /// Omits api calls for mock object.
        /// </summary>
        public IActionResult MakeApiCalls(BankRequestPayload content)
        {
            throw new NotImplementedException();
        }
    }
}
