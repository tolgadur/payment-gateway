//-----------------------------------------------------------------------------------------------------------
// <copyright file="PaymentGatewayController.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json.Linq;
    using app.PaymentGatewayService;
    using Microsoft.Extensions.Configuration;

    [ApiController]
    [Route("[controller]")]
    public class PaymentGatewayController : ControllerBase
    {
        private readonly ILogger<PaymentGatewayController> _logger;

        public PaymentGatewayController(IConfiguration configuration, ILogger<PaymentGatewayController> logger)
        {
            _logger = logger;
            ConnectionHelper.Init(configuration);
        }

        /// <summary>
        /// Gets payment details by id.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet("payment/{paymentId}")]
        public async Task<IActionResult> GetPaymentDetails([FromUri]string paymentId = null)
        {
            if (string.IsNullOrWhiteSpace(paymentId))
            {
                return BadRequest("Payment Id is not specified.");
            }

            var paymentDetails = ConnectionHelper.GetPaymentById(paymentId);

            // return response
            return new OkObjectResult(new PaymentDetailsPayload().Map(paymentDetails));
        }

        /// <summary>
        /// Processes the payment and returns whether transaction was successful.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost("payment/process")]
        public async Task<IActionResult> ProcessPayment(PaymentDetailsPayload payload)
        {
            return await PaymentGateway.ProcessPayment(payload);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
    }
}
