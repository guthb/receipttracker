using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ReceiptTracker.Models;

namespace ReceiptTracker.DAL
{
    public class ReceiptContext : ApplicationDbContext
    {
        public virtual DbSet<ReceiptTrackerModel> Receipts { get; set; }
        public virtual DbSet<ReceiptTrackerUserModel> ReceiptUsers { get; set; }
        
    }
}