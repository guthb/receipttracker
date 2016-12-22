using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ReceiptTracker.Models;
using System.Data.Entity.Validation;

namespace ReceiptTracker.DAL
{
    public class ReceiptContext : ApplicationDbContext //DbContext
    {
        public virtual DbSet<ReceiptModel> Receipts { get; set; }
        public virtual DbSet<UserModel> ReceiptUsers { get; set; }

        //public override int SaveChanges()
        //{
        //    try
        //    {
        //        return base.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        throw new Exception();
        //    }


        //}




    }
}