using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReceiptTracker.Models
{
    public class ReceiptModel
    {
        [Key]
        public int ReceiptCapturedId { get; set; }

        public string ReceiptType { get; set; }

        public string Receipt { get; set; }

        public string Retailer { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string S3BuckedId { get; set; }

        public string Purpose { get; set; }

    }
}