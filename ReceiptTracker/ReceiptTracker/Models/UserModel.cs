﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace ReceiptTracker.Models
{
    public class UserModel 
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public ApplicationUser ReceiptUser { get; set; }
        public string AppEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public virtual List<ReceiptModel> Receipts { get; set; } this breaks my api for Getting Receipts
    }
}