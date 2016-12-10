﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReceiptTracker.Models
{
    public class ReceiptTrackerUserModel 
    {
        public class User
        {
            public int UserId { get; set; }
            public ApplicationUser ReceiptUser { get; set; }

        }

    }
}