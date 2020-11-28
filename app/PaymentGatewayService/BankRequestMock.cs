
//-----------------------------------------------------------------------------------------------------------
// <copyright file="IBankRequestTest.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService
{
    using app.PaymentGatewayService.Models.ApiModels;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using System;

    public class BankRequestMock : IBankRequest
    {
        IActionResult IBankRequest.ProcessPayment(BankRequestPayload content)
        {
            JObject response = new JObject();
            response["PaymentId"] = Guid.NewGuid().ToString();
            response["Success"] = true;

            return new OkObjectResult(response);

        }
    }
}
