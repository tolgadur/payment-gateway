//-----------------------------------------------------------------------------------------------------------
// <copyright file="BankRequestPayload.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService.Models.ApiModels
{
    using app.Controllers;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="BankRequestPayload" />.
    /// </summary>
    public class BankRequestPayload
    {
        /// <summary>
        /// Gets or sets the senders card number.
        /// </summary>
        [JsonProperty("SenderCardNumber", Required = Required.Always)]
        public string SenderCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the senders name.
        /// </summary>
        [JsonProperty("SenderName", Required = Required.Always)]
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the senders cvv.
        /// </summary>
        [JsonProperty("SenderCvv", Required = Required.Always)]
        public string SenderCvv { get; set; }

        /// <summary>
        /// Gets or sets the recipients card number.
        /// </summary>
        [JsonProperty("RecipientCardNumber", Required = Required.Always)]
        public string RecipientCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the recipients name.
        /// </summary>
        [JsonProperty("RecipientName", Required = Required.Always)]
        public string RecipientName { get; set; }

        /// <summary>
        /// Gets or sets the recipients cvv.
        /// </summary>
        [JsonProperty("RecipientCvv", Required = Required.Always)]
        public string RecipientCvv { get; set; }

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
        /// Gets or sets the expiry date
        /// </summary>
        [JsonProperty("ExpiryMonth", Required = Required.Always;)]
        public DateTime ExpiryMonth { get; set; }

        /// <summary>
        /// Maps to models to bank request payload.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>
        /// The <see cref="GetPaymentDetailsResponse" />.
        /// </returns>
        public BankRequestPayload  Map(ProcessPaymentPayload payload, MerchantDetails merchantDetails, bool isPayout)
        {
            this.Amount = payload.Amount;
            this.Currency = payload.Currency;
            this.Reference = payload.Reference;
            this.ExpiryMonth = payload.ExpiryMonth;

            // set recipeint and sender depending on whether money is sent or received from merchant.
            if (isPayout)
            {
                this.RecipientName = payload.Name;
                this.RecipientCardNumber = payload.CardNumber;
                this.RecipientCvv = payload.Cvv;
                this.SenderName = merchantDetails.Name;
                this.SenderCardNumber = merchantDetails.CardNumber;
                this.SenderCvv = merchantDetails.Cvv;
            }
            else
            {
                this.RecipientName = merchantDetails.Name;
                this.RecipientCardNumber = merchantDetails.CardNumber;
                this.RecipientCvv = merchantDetails.Cvv;
                this.SenderName = payload.Name;
                this.SenderCvv = payload.Cvv;
                this.SenderCardNumber = payload.CardNumber;
            }

            return this;
        }
    }
}
