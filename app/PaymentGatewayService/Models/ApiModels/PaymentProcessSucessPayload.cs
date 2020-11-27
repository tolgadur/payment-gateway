//-----------------------------------------------------------------------------------------------------------
// <copyright file="PaymentDetailsResponse.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------



namespace app.PaymentGatewayService.Models
{
    using app.Controllers;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    /// <summary>
    /// Defines the <see cref="PaymentProcessSucessPayload" />.
    /// </summary>
    public class PaymentProcessSucessPayload
    {
        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        [JsonProperty("Id", Required = Required.Always)]
        public string Id { get; set; }

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
        /// The <see cref="PaymentDetails" />.
        /// </returns>
        public PaymentProcessSucessPayload Map(PaymentDetails paymentDetails)
        {
            this.Id = paymentDetails.Id;
            this.Success = paymentDetails.Success;
            return this;
        }

    }
}
