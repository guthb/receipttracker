using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptTracker.DAL;
using Moq;
using System.Data.Entity;
using ReceiptTracker.Models;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;


namespace ReceiptTracker.Tests.DAL
{
    [TestClass]
    public class ReceiptRepoTests
    {

        private Mock<DbSet<ReceiptTrackerUserModel>> mock_users { get; set; }
        private Mock<DbSet<ReceiptTrackerModel>> mock_receipts { get; set; }
        
        private Mock<DbSet<ApplicationUser>> mock_app_users { get; set; }
        private Mock<ReceiptContext> mock_context { get; set; }
        private ReceiptRepository Repo { get; set; }

        private List<ReceiptTrackerUserModel> users { get; set; }
        private List<ReceiptTrackerModel> receipts { get; set; }

        private Mock<UserManager<ApplicationUser>> mock_user_manager_context { get; set; }
        private List<ApplicationUser> app_users { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ReceiptContext>();
            mock_users = new Mock<DbSet<ReceiptTrackerUserModel>>();
            mock_receipts = new Mock<DbSet<ReceiptTrackerModel>>();
            mock_app_users = new Mock<DbSet<ApplicationUser>>();
            mock_user_manager_context = new Mock<UserManager<ApplicationUser>>();
            Repo = new ReceiptRepository(mock_context.Object);

            receipts = new List<ReceiptTrackerModel>();
            ApplicationUser yeldarba = new ApplicationUser { Email = "yeldarba@test.com", UserName = "yeldarba@guthb.com", Id = "000001" };
            ApplicationUser yeldarbb = new ApplicationUser { Email = "yeldarbb@test.com", UserName = "yeldarbb@guthb.com", Id = "000002" };

            app_users = new List<ApplicationUser>()
            {
                yeldarba,
                yeldarbb
            };

            users = new List<ReceiptTrackerUserModel>
            {
                new User {
                    UserId = 1,
                    ReceiptUser = yeldarba
                }
            };



        }








        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
