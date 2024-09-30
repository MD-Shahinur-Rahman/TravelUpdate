﻿using Microsoft.Extensions.Logging.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelUpdate.Models
{
    public class PackageAccounts
    {
        public int PackageAccountsID { get; set; }

        public int PackageID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalFoodCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalTransPortCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAccomodationCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalOtherCost { get; set; }
       // public decimal CompanyCost { get; set; }
       [Column(TypeName = "decimal(18,2)")]      
        public decimal TotalEarn { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalLoss { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalProfit { get; set; }


        public Package? Package { get; set; }


    }
}
