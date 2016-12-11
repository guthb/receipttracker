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

        [Required]
        public string ReceiptType { get; set; }

        [Required]
        public string Receipt { get; set; }

        [Required]
        public string Retailer { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public string S3BuckedId { get; set; }

        [Required]
        public string Purpose { get; set; }

    }
}