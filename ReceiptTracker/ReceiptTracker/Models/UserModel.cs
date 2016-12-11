using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace ReceiptTracker.Models
{
    public class UserModel 
    {
        public class User
        {
            [Key]
            public int UserId { get; set; }
            [Required]
            public ApplicationUser ReceiptUser { get; set; }

        }

    }
}