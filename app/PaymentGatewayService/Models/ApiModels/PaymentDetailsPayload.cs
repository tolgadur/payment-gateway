//-----------------------------------------------------------------------------------------------------------
// <copyright file="PaymentDetailsPayload.cs">
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
    /// Defines the <see cref="PaymentDetailsPayload" />.
    /// </summary>
    public class PaymentDetailsPayload
    {
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
        [JsonProperty("Success", Required = Required.Default)]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the expiry date
        /// </summary>
        [JsonProperty("ExpiryMonth", Required = Required.Default)]
        public DateTime ExpiryMonth { get; set; }
    }
}
