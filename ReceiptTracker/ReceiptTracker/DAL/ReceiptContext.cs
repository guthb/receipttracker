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
        public virtual DbSet<ReceiptModel> Receipts { get; set; }
        public virtual DbSet<UserModel> ReceiptUsers { get; set; }
        
    }
}