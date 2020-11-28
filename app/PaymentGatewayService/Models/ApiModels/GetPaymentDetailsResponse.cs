//-----------------------------------------------------------------------------------------------------------
// <copyright file="ProcessPaymentResponse.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.Controllers
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="GetPaymentDetailsResponse" />.
    /// </summary>
    public class GetPaymentDetailsResponse
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
        /// Gets or sets a value indicating whether the transaction was a success.
        /// </summary>
        [JsonProperty("Success", Required = Required.Always)]
        public bool Success { get; set; }


        /// <summary>
        /// Maps the model to the response json.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>
        /// The <see cref="GetPaymentDetailsResponse" />.
        /// </returns>
        public GetPaymentDetailsResponse Map(PaymentDetails paymentDetails)
        {
            this.CardNumber = paymentDetails.CardNumber;
            this.Amount = paymentDetails.Amount;
            this.Currency = paymentDetails.Currency;
            this.Success = paymentDetails.Success;
            return this;
        }
    }
}
