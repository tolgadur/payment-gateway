//-----------------------------------------------------------------------------------------------------------
// <copyright file="PaymentGatewayController.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.Controllers
{
    using System.Web.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using app.PaymentGatewayService;
    using Microsoft.Extensions.Configuration;
    using app.PaymentGatewayService.Models.ApiModels;
    using System;

    [ApiController]
    [Route("payments")]
    public class PaymentGatewayController : ControllerBase
    {
        public PaymentGatewayController(IConfiguration configuration)
        {
            ConnectionHelper.Init(configuration);
        }

        /// <summary>
        /// Processes the payment and returns whether transaction was successful.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost("set/merchant/details")]
        public IActionResult SetMerchantDetails(SetMerchantDetailsPayload payload)
        {
            return PaymentGateway.SetMerchantDetails(payload);
        }

        /// <summary>
        /// Processes the payment and returns whether transaction was successful.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost("process")]
        public IActionResult ProcessPayment(ProcessPaymentPayload payload)
        {
            if (DateTime.Now > payload.ExpiryDate)
            {
                return BadRequest("The customers credit card has expired.");
            }

            return PaymentGateway.ProcessPayment(payload, new BankRequestMock());
        }

        /// <summary>
        /// Gets payment details by id.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet("{paymentId}")]
        public IActionResult GetPaymentDetails([FromUri] string paymentId = null)
        {
            if (string.IsNullOrWhiteSpace(paymentId))
            {
                return BadRequest("Payment Id is not specified.");
            }

            // get payment details
            var paymentDetails = ConnectionHelper.GetPaymentById(paymentId);
            if (paymentDetails == null)
            {
                return BadRequest("Payment Id is wrong.");
            }

            // mask card number and return
            paymentDetails.CardNumber = new string('*', paymentDetails.CardNumber.Length);
            return new OkObjectResult(paymentDetails);
        }

        /// <summary>
        /// Short message displayed for debugging purposes.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Api is running.");
        }
    }
}
