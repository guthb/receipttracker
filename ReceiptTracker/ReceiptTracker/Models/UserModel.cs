using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ReceiptTracker.Models
{
    public class UserModel 
    {
        public class User
        {
            public int UserId { get; set; }
            public ApplicationUser ReceiptUser { get; set; }

        }

    }
}