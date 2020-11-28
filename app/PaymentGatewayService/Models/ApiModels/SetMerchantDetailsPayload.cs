//-----------------------------------------------------------------------------------------------------------
// <copyright file="MerchantDetailsPayload.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService.Models.ApiModels
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="SetMerchantDetailsPayload" />.
    /// </summary>
    public class SetMerchantDetailsPayload
    {
        /// <summary>
        /// Gets or sets the merchants name.
        /// </summary>
        [JsonProperty("Name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        [JsonProperty("CardNumber", Required = Required.Always)]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        [JsonProperty("Cvv", Required = Required.Always)]
        public string Cvv { get; set; }
    }
}
