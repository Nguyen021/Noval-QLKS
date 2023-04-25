using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagerHotel.Models
{
    public class ReceiptSurcharge
    {
        [Key]
        public int ReceiptSurchargeId { get; set; }
        public int ReceiptId { get; set; }
        public Receipt Receipt { get; set; }

        public int SurchargeId { get; set; }
        public Surcharge Surcharge { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice => Quantity * Surcharge.Price;
    }
}