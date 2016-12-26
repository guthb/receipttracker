using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            //pdf html url
        [Required]
        public string Receipt { get; set; }
            //pdf points to s3 object
            //html  - render
            //url - tbd

        [Required]
        public string Retailer { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public string S3BuckedId { get; set; }

        [Required]
        public string Purpose { get; set; }

        [ForeignKey("ReceiptUser")]
        public int UserId { get; set; }
        
        public virtual UserModel ReceiptUser { get; set; }

    }
}