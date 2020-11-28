//-----------------------------------------------------------------------------------------------------------
// <copyright file="IBankRequest.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService
{
    using app.PaymentGatewayService.Models.ApiModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public interface IBankRequest
    {
        IActionResult ProcessPayment(BankRequestPayload content);
    }
}
