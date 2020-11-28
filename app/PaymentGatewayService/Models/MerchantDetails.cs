//-----------------------------------------------------------------------------------------------------------
// <copyright file="MerchantDetails.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService.Models
{
    using app.PaymentGatewayService.Models.ApiModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="MerchantDetails" />.
    /// </summary>
    public class MerchantDetails
    {
        /// <summary>
        /// Gets or sets the merchants name.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the merchants name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public string Cvv { get; set; }

        /// <summary>
        /// Maps the api payload
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>
        /// The <see cref="PaymentDetails" />.
        /// </returns>
        public MerchantDetails Map(SetMerchantDetailsPayload payload)
        {
            this.Name = payload.Name;
            this.CardNumber = payload.CardNumber;
            this.Cvv = payload.Cvv;
            return this;
        }

    }
}
