//-----------------------------------------------------------------------------------------------------------
// <copyright file="PaymentDetailsPayload.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.Controllers
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="ProcessPaymentPayload" />.
    /// </summary>
    public class ProcessPaymentPayload
    {
        /// <summary>
        /// Gets or sets the merhcant identifier.
        /// </summary>
        [JsonProperty("MerchantIdentifier", Required = Required.Always)]
        public string MerchantIdentifier { get; set; }

        /// <summary>
        /// Gets or sets whether it's a payout. False implies that it tis a request.
        /// </summary>
        [JsonProperty("IsPayout", Required = Required.Always)]
        public bool IsPayout { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        [JsonProperty("CardNumber", Required = Required.Always)]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the customers name.
        /// </summary>
        [JsonProperty("Name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [JsonProperty("Amount", Required = Required.Always)]
        public float Amount { get; set; }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        [JsonProperty("Reference", Required = Required.Default)]
        public float Reference { get; set; }

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
        /// Gets or sets the expiry date
        /// </summary>
        [JsonProperty("ExpiryMonth", Required = Required.Always)]
        public DateTime ExpiryMonth { get; set; }
    }
}
