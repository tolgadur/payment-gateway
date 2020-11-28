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
    using Microsoft.Extensions.Logging;
    using app.PaymentGatewayService;
    using Microsoft.Extensions.Configuration;
    using app.PaymentGatewayService.Models.ApiModels;

    [ApiController]
    [Route("payments")]
    public class PaymentGatewayController : ControllerBase
    {
        private readonly ILogger<PaymentGatewayController> _logger;

        public PaymentGatewayController(IConfiguration configuration, ILogger<PaymentGatewayController> logger)
        {
            _logger = logger;
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
            return await PaymentGateway.SetMerchantDetails(payload);
        }

        /// <summary>
        /// Processes the payment and returns whether transaction was successful.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost("process")]
        public IActionResult ProcessPayment(ProcessPaymentPayload payload)
        {
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

            var paymentDetails = ConnectionHelper.GetPaymentById(paymentId);
            return new OkObjectResult(paymentDetails);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
    }
}
