//-----------------------------------------------------------------------------------------------------------
// <copyright file="SetMerchantDetailsResponse.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="SetMerchantDetailsResponse" />.
    /// </summary>
    public class SetMerchantDetailsResponse
    {
        /// <summary>
        /// Gets or sets the merchants name.
        /// </summary>
        [JsonProperty("MerchantIdentifier", Required = Required.Always)]
        public string Id { get; set; }

        /// <summary>
        /// Maps the model to the response json.
        /// </summary>
        /// <param name="merchantDetails">The merchantDetails.</param>
        /// <returns>
        /// The <see cref="PaymentDetails" />.
        /// </returns>
        public SetMerchantDetailsResponse Map(MerchantDetails merchantDetails)
        {
            this.Id = merchantDetails.Id;
            return this;
        }

    }
}
