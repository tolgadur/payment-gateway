//-----------------------------------------------------------------------------------------------------------
// <copyright file="PaymentDetails.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using app.PaymentGatewayService.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Defines the <see cref="PaymentDetails" />.
    /// </summary>
    public class PaymentDetails
    {

        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        [JsonProperty("Id", Required = Required.Always)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        [JsonProperty("CardNumber", Required = Required.Always)]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [JsonProperty("Amount", Required = Required.Always)]
        public float Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        [JsonProperty("Currency", Required = Required.Always)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the Cvv.
        /// </summary>
        [JsonProperty("Cvv", Required = Required.Always)]
        public string Cvv { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction was a success.
        /// </summary>
        [JsonProperty("Success", Required = Required.Always)]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the expiry date
        /// </summary>
        [JsonProperty("ExpiryMonth", Required = Required.Always)]
        public DateTime ExpiryMonth { get; set; }

        /// <summary>
        /// Maps the api payload
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>
        /// The <see cref="PaymentDetails" />.
        /// </returns>
        public PaymentDetails Map(PaymentDetailsPayload payload, bool success)
        {
            this.Amount = payload.Amount;
            this.CardNumber = payload.CardNumber;
            this.Currency = payload.Currency;
            this.Cvv = payload.Cvv;
            this.Success = success;
            this.ExpiryMonth = payload.ExpiryMonth;
            return this;
        }
    }
}
