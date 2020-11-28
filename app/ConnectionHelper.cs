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
    using app.PaymentGatewayService.Models;

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
        /// This will return the payment with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns> The Connectionstring </returns>
        public static PaymentDetails GetPaymentById(string id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<PaymentDetails>(String.Format("SELECT * FROM Payments WHERE Id='{0}'", id), new DynamicParameters()).FirstOrDefault();
            }
        }

        /// <summary>
        /// This will save a payment in the database.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns> The Connectionstring </returns>
        public static void SavePayment(PaymentDetails paymentDetails)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Payments (Id, CardNumber, Amount, Currency, Cvv, Success, ExpiryDate) VALUES " +
                    "(@Id, @CardNumber, @Amount, @Currency, @Cvv, @Success, @ExpiryDate)", paymentDetails);
            }
        }

        /// <summary>
        /// This will delete the payment with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns> The Connectionstring </returns>
        public static void DeletePaymentById(string id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(String.Format("DELETE Payment WHERE Id='{0}'", id));
            }
        }

        /// <summary>
        /// This will return the merchant with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns> The Connectionstring </returns>
        public static MerchantDetails GetMerchantById(string id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<MerchantDetails>(String.Format("SELECT * FROM Merchants WHERE Id='{0}'", id), new DynamicParameters()).FirstOrDefault();
            }
        }

        /// <summary>
        /// This will save the merchants details in the database.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns> The Connectionstring </returns>
        public static void SaveMerchantDetails(MerchantDetails merchantDetails)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Merchants (Id, Name, CardNumber, Cvv) VALUES (@Id, @Name, @CardNumber, @Cvv)", merchantDetails);
            }
        }

        /// <summary>
        /// This will delete the merchant with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns> The Connectionstring </returns>
        public static void DeleteMerchantById(string id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(String.Format("DELETE Merchant WHERE Id='{0}'", id));
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
