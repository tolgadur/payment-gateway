//-----------------------------------------------------------------------------------------------------------
// <copyright file="IBankRequest.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService
{
    using app.PaymentGatewayService.Models;
    using app.PaymentGatewayService.Models.ApiModels;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="IBankRequest" />.
    /// </summary>
    public interface IBankRequest
    {
        /// <summary>
        /// Prepares api calls and casts result into ProcessPaymentResult.
        /// </summary>
        ProcessPaymentResponse ProcessPayment(BankRequestPayload content);

        /// <summary>
        /// Makes the actual calls to the banks api.
        /// </summary>
        IActionResult MakeApiCalls(BankRequestPayload content);

    }
}
