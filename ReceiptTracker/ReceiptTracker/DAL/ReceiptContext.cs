using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ReceiptTracker.Models;

namespace ReceiptTracker.DAL
{
    public class ReceiptContext : DbContext
    {
        public virtual DbSet<ReceiptTrackerViewModel> ReceiptTrackerViewModels { get; set; }
        
    }
}