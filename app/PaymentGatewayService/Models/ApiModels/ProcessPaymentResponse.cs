//-----------------------------------------------------------------------------------------------------------
// <copyright file="PaymentDetailsResponse.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------



namespace app.PaymentGatewayService.Models
{
    using app.Controllers;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="ProcessPaymentResponse" />.
    /// </summary>
    public class ProcessPaymentResponse
    {
        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        [JsonProperty("PaymentId", Required = Required.Always)]
        public string PaymentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction was a success.
        /// </summary>
        [JsonProperty("Success", Required = Required.Always)]
        public bool Success { get; set; }

        /// <summary>
        /// Maps the payment details.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>
        /// The <see cref="GetPaymentDetailsResponse" />.
        /// </returns>
        public ProcessPaymentResponse Map(PaymentDetails paymentDetails)
        {
            this.PaymentId = paymentDetails.Id;
            this.Success = paymentDetails.Success;
            return this;
        }

    }
}
