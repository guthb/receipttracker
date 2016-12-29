namespace ReceiptTracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ReceiptTracker.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ReceiptTracker.DAL.ReceiptContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ReceiptTracker.DAL.ReceiptContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //if (System.Diagnostics.Debugger.IsAttached == false) {
            //    System.Diagnostics.Debugger.Launch();
            //}

            var ApplicationUser = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "frank@test.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                UserName = "frank@test.com",
                //ReceiptUser = new UserModel() { UserId = 1, AppEmail = "John.Doe@guthb.com", FirstName = "John", LastName = "Doe" }

            };

            var _ReceiptUser = new UserModel() { UserId = 1, AppEmail = "John.Doe@guthb.com", FirstName = "John", LastName = "Doe", ReceiptUser = ApplicationUser };

            ApplicationUser.ReceiptUser = _ReceiptUser;

            context.Users.AddOrUpdate(u => u.Email, ApplicationUser);

            //context.Users.AddOrUpdate(u => u.Id,

            //    new ApplicationUser()
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Email = "guppy96@gmail.com",
            //        SecurityStamp = Guid.NewGuid().ToString(),
            //        PhoneNumberConfirmed = false,
            //        TwoFactorEnabled = false,
            //        EmailConfirmed = true,
            //        LockoutEnabled = true,
            //        AccessFailedCount = 0,
            //        UserName = "guppy96@gmail.com",
            //        ReceiptUser = new UserModel() { UserId = 1, AppEmail = "John.Doe@guthb.com", FirstName = "John", LastName = "Doe" }

            //    }

            //);

            //context.ReceiptUsers.AddOrUpdate(r => r.UserId,
            //    new UserModel() { UserId = 1, AppEmail = "John.Doe@guthb.com",
            //        FirstName = "John",
            //        LastName = "Doe",
            //        ReceiptUser = new ApplicationUser()
            //        {
            //            Id = Guid.NewGuid().ToString(),
            //            Email = "guppy96@gmail.com",
            //            SecurityStamp = Guid.NewGuid().ToString(),
            //            PhoneNumberConfirmed = false,
            //            TwoFactorEnabled = false,
            //            EmailConfirmed = true,
            //            LockoutEnabled = true,
            //            AccessFailedCount = 0,
            //            UserName = "guppy96@gmail.com",
            //        }
            //    });


            //context.ReceiptUsers.AddOrUpdate(u => u.UserId,

            //    new UserModel() { UserId = 1, AppEmail= "John.Doe@guthb.com", FirstName = "Joe", LastName="Doe" },
            //    new UserModel() { UserId = 2, AppEmail = "Jim.Dough@guthb.com", FirstName = "Jim", LastName = "Dough" },
            //    new UserModel() { UserId = 3, AppEmail = "James.GreenBacks@guthb.com", FirstName = "James", LastName = "Greenbacks" },
            //    new UserModel() { UserId = 4, AppEmail = "Jane.Doe@guthb.com", FirstName = "Jane", LastName = "Doe" },
            //    new UserModel() { UserId = 5, AppEmail = "Fannie.Mae@guthb,com", FirstName = "Fannie", LastName = "Mae" },
            //    new UserModel() { UserId = 6, AppEmail = "Frank.Smith@guthb.com", FirstName = "Frank", LastName = "Smith" }
            //);

            context.Receipts.AddOrUpdate(r => r.ReceiptCapturedId,
                new ReceiptModel() { UserId = 1, ReceiptCapturedId = 1, ReceiptType = "pdf", Receipt = "pdf", Retailer = "HOME DEPOT", PurchaseDate = new DateTime(2016, 12, 01), S3BuckedId = "1", Purpose = "Fun" },
                new ReceiptModel() { UserId = 1, ReceiptCapturedId = 2, ReceiptType = "url", Receipt = "url", Retailer = "WAL-MART", PurchaseDate = new DateTime(2016, 12, 02), S3BuckedId = "1", Purpose = "Party" },
                new ReceiptModel() { UserId = 1, ReceiptCapturedId = 3, ReceiptType = "html", Receipt = "html", Retailer = "KROGER", PurchaseDate = new DateTime(2016, 12, 03), S3BuckedId = "1", Purpose = "Car" }
            //new ReceiptModel() { ReceiptCapturedId = 4, ReceiptType = "pdf", Receipt = "pdf", Retailer = "STARBUCKS", PurchaseDate = new DateTime(2016, 12, 04), S3BuckedId = "2", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 5, ReceiptType = "url", Receipt = "url", Retailer = "SHELL", PurchaseDate = new DateTime(2016, 12, 05), S3BuckedId = "2", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 6, ReceiptType = "html", Receipt = "html", Retailer = "MAPCO", PurchaseDate = new DateTime(2016, 12, 06), S3BuckedId = "2", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 7, ReceiptType = "pdf", Receipt = "pdf", Retailer = "TEXACO", PurchaseDate = new DateTime(2016, 12, 07), S3BuckedId = "3", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 8, ReceiptType = "url", Receipt = "url", Retailer = "IGA", PurchaseDate = new DateTime(2016, 12, 08), S3BuckedId = "3", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 9, ReceiptType = "html", Receipt = "html", Retailer = "CHURCHES", PurchaseDate = new DateTime(2016, 12, 09), S3BuckedId = "3", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 10, ReceiptType = "pdf", Receipt = "pdf", Retailer = "XXX", PurchaseDate = new DateTime(2016, 12, 10), S3BuckedId = "4", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 11, ReceiptType = "url", Receipt = "url", Retailer = "FREDS", PurchaseDate = new DateTime(2016, 12, 11), S3BuckedId = "4", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 12, ReceiptType = "html", Receipt = "html", Retailer = "PIGGLY WIGGLY", PurchaseDate = new DateTime(2016, 12, 12), S3BuckedId = "4", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 13, ReceiptType = "pdf", Receipt = "pdf", Retailer = "HILLS", PurchaseDate = new DateTime(2016, 12, 13), S3BuckedId = "5", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 14, ReceiptType = "url", Receipt = "url", Retailer = "FOOD CITY", PurchaseDate = new DateTime(2016, 12, 14), S3BuckedId = "5", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 15, ReceiptType = "html", Receipt = "html", Retailer = "MARATHON", PurchaseDate = new DateTime(2016, 12, 15), S3BuckedId = "5", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 16, ReceiptType = "pdf", Receipt = "pdf", Retailer = "PORTLAND BREW", PurchaseDate = new DateTime(2016, 12, 16), S3BuckedId = "6", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 17, ReceiptType = "url", Receipt = "url", Retailer = "YAZHOO", PurchaseDate = new DateTime(2016, 12, 17), S3BuckedId = "6", Purpose = "" },
            //new ReceiptModel() { ReceiptCapturedId = 18, ReceiptType = "html", Receipt = "html", Retailer = "REI", PurchaseDate = new DateTime(2016, 12, 18), S3BuckedId = "6", Purpose = "" }
            );

        }
    }
}

