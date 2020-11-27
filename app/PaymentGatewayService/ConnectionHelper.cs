//-----------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionHelper.cs">
//  Copyright (c) Tolga Hasan Dur. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------------


namespace app.PaymentGatewayService
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Data.SQLite;
    using System.Data;
    using Dapper;
    using app.Controllers;

    public static class ConnectionHelper
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private static IConfiguration _configuration;

        /// <summary>
        /// Initializes the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Init(IConfiguration config)
        {
            _configuration = config;
        }

        /// <summary>
        /// This will return the Connectionstring from our config file.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns> The Connectionstring </returns>
        public static PaymentDetails GetPaymentById(string id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PaymentDetails>("SELECT * FROM Payments WHERE 'Id' =" + id, new DynamicParameters());
                return (PaymentDetails)output;
            }
        }

        /// <summary>
        /// This will save a payment in the database
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns> The Connectionstring </returns>
        public static void SavePayment(PaymentDetails paymentDetails)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Payments (Id, CardNumber, Amount, Currency, Cvv, Success, ExpiryMonth) VALUES " +
                    "(@Id, @CardNumber, @Amount, @Currency, @Cvv, @Success, @ExpiryMonth)", paymentDetails);
            }
        }

        /// <summary>
        /// This will return the Connectionstring from our config file.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns> The Connectionstring </returns>
        private static string LoadConnectionString(string id = "Default")
        {
            return _configuration.GetConnectionString(id);
        }
    }
}
