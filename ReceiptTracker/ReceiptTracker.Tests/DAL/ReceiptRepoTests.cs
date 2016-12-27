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
        private Mock<DbSet<UserModel>> mock_users { get; set; }
        private Mock<DbSet<ReceiptModel>> mock_receipts { get; set; }
        
        private Mock<DbSet<ApplicationUser>> mock_app_users { get; set; }
        private Mock<ReceiptContext> mock_context { get; set; }
        private ReceiptRepository Repo { get; set; }

        private List<UserModel> users { get; set; }
        private List<ReceiptModel> receipts { get; set; }

        private Mock<UserManager<ApplicationUser>> mock_user_manager_context { get; set; }
        private List<ApplicationUser> app_users { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ReceiptContext>();
            mock_users = new Mock<DbSet<UserModel>>();
            mock_receipts = new Mock<DbSet<ReceiptModel>>();
            mock_app_users = new Mock<DbSet<ApplicationUser>>();
            mock_user_manager_context = new Mock<UserManager<ApplicationUser>>();
            Repo = new ReceiptRepository(mock_context.Object);

            receipts = new List<ReceiptModel>();

            ApplicationUser yeldarba = new ApplicationUser { Email = "yeldarba@test.com", UserName = "yeldarba", Id = "000001" };

            ApplicationUser yeldarbb = new ApplicationUser { Email = "yeldarbb@test.com", UserName = "yeldarbb", Id = "000002" };

            app_users = new List<ApplicationUser>()
            {
                yeldarba,
                yeldarbb
            };

            users = new List<UserModel>
            {
                //guide for users
                //Id = Guid.NewGuid().ToString(),
                //Email = "test@test.com",
                //SecurityStamp = Guid.NewGuid().ToString(),
                //PhoneNumberConfirmed = false,
                //TwoFactorEnabled = false,
                //EmailConfirmed = true,
                //LockoutEnabled = true,
                //AccessFailedCount = 0,
                //UserName = "test@test.com",
                //ReceiptUser = new UserModel() { UserId = 1, AppEmail = "John.Doe@guthb.com", FirstName = "John", LastName = "Doe" }

                new UserModel {
                   UserId = 1,
                   AppEmail = "fred.rogers@test.com",
                   FirstName = "fred",
                   LastName = "rogers",
                   ReceiptUser =  new ApplicationUser () {UserName= "fred@somewhere.com" }

                   
                },
                   

                new UserModel {
                    UserId = 2,                    
                    AppEmail = "king.fridayb@test.com",
                    FirstName = "king",
                    LastName = "friday",
                    ReceiptUser = new ApplicationUser () {UserName= "king@somewhere.com" }
               }
            };
        } 

        public void ConnectToDataStore()
        {
            var query_users = users.AsQueryable();
            
            mock_users.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(query_users.Provider);
            mock_users.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(query_users.Expression);
            mock_users.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(query_users.ElementType);
            mock_users.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(() => query_users.GetEnumerator());

            mock_context.Setup(c => c.ReceiptUsers).Returns(mock_users.Object);
            mock_users.Setup(u => u.Add(It.IsAny<UserModel>())).Callback((UserModel t) => users.Add(t));
            mock_users.Setup(u => u.Remove(It.IsAny<UserModel>())).Callback((UserModel t) => users.Remove(t));

            var query_app_users = app_users.AsQueryable();

            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(query_app_users.Provider);
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(query_app_users.Expression);
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(query_app_users.ElementType);
            mock_app_users.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(() => query_app_users.GetEnumerator());

            mock_context.Setup(c => c.Users).Returns(mock_app_users.Object);
          


            var query_receipts = receipts.AsQueryable();

            mock_receipts.As<IQueryable<ReceiptModel>>().Setup(m => m.Provider).Returns(query_receipts.Provider);
            mock_receipts.As<IQueryable<ReceiptModel>>().Setup(m => m.Expression).Returns(query_receipts.Expression);
            mock_receipts.As<IQueryable<ReceiptModel>>().Setup(m => m.ElementType).Returns(query_receipts.ElementType);
            mock_receipts.As<IQueryable<ReceiptModel>>().Setup(m => m.GetEnumerator()).Returns(() => query_receipts.GetEnumerator());

            mock_context.Setup(c => c.Receipts).Returns(mock_receipts.Object);
            mock_receipts.Setup(u => u.Add(It.IsAny<ReceiptModel>())).Callback((ReceiptModel t) => receipts.Add(t));
            mock_receipts.Setup(u => u.Remove(It.IsAny<ReceiptModel>())).Callback((ReceiptModel t) => receipts.Remove(t));

            
        }

        [TestMethod]
        public void RepoEnsureCanCreateInstance()
        {
            // arrange

            // act
            ReceiptRepository repo = new ReceiptRepository();

            // assert
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureICanGetUserNames()
        {

            // arrange
            ConnectToDataStore();

            // act
            
            List<string> usernames = Repo.GetUserNames();

            // assert
            Assert.AreEqual(2, usernames.Count);

        }

        [TestMethod]
        public void RepoEnsureUserNameExists()
        {

            // arrange
            ConnectToDataStore();

            // act
            bool userExists = Repo.UserNameExists("fred@somewhere.com");

            // assert
            Assert.IsTrue(userExists);

        }

        [TestMethod]
        public void RepoEnsureUserExistsOfSpecificUserName()
        {

            // arrange
            ConnectToDataStore();

            // act
            UserModel foundUser = Repo.UserNameExistsofUserModel("fred@somewhere.com");

            // assert
            Assert.IsNotNull(foundUser);
        }

        [TestMethod]
        public void RepoEnsureUserCanBeRemoved()
        {
            // arrange
            ConnectToDataStore();
            UserModel test_userModel = new UserModel
            {
                UserId = 5,
                AppEmail = "test.user@guthb.com",
                FirstName = "test",
                LastName = "user"
            };
            UserModel next_test_userModel = new UserModel
            {
                UserId = 6,
                AppEmail = "mest.tser@guthb.com",
                FirstName = "mest",
                LastName = "tser"
            };


            // act
            UserModel removed_userModel = Repo.RemoveUser(5);
            int expected_test_users = 1;
            int actual_test_users = Repo.Context.ReceiptUsers.Count();

            // assert
            Assert.AreEqual(expected_test_users, actual_test_users);
            Assert.IsNotNull(removed_userModel);

        }

        [TestMethod]
        public void RepoEnsureUserCanBeModified()
        {
            // arrange

            // act

            // assert
        }


        [TestMethod]
        public void RepoEnsureICanAddAReceipt()
        {

            // arrange
            ConnectToDataStore();
            ReceiptModel test_receipt = new ReceiptModel
            {
                ReceiptCapturedId = 1,
                ReceiptType = "pdf",
                Receipt = "testReceipt",
                Retailer ="711",
                PurchaseDate =DateTime.Now,
                S3BuckedId ="3333",
                Purpose ="Stuff",
                ReceiptUser = new UserModel { UserId = 1,
                                              AppEmail = "John.Doe@guthb.com",
                                              FirstName = "John",
                                              LastName = "Doe" }
            };
         

            // act
            Repo.AddReceipt(test_receipt);
            int actual_receipt_count = Repo.GetReceipts().Count;
            int expected_receipt_count = 1;

            // assert
            Assert.AreEqual(expected_receipt_count, actual_receipt_count);
        }

        [TestMethod]
        public void RepoEnsureICanAddToReceiptWithData()
        {

            // arrange
            ReceiptModel test_receipt = new ReceiptModel
            {
                ReceiptCapturedId = 1,
                ReceiptType = "pdf",
                Receipt = "testReceipt",
                Retailer = "711",
                PurchaseDate = DateTime.Now,
                S3BuckedId = "3333",
                Purpose = "Old Purpose",
                ReceiptUser = new UserModel
                {
                    UserId = 1,
                    AppEmail = "John.Doe@guthb.com",
                    FirstName = "John",
                    LastName = "Doe"
                }
            };

            string update_purpose = "new_purpose";

            // act
            Repo.AddReceiptPurpose(update_purpose);

            // assert
            Assert.AreEqual(test_receipt.Purpose, update_purpose);

        }

        [TestMethod]
        public void RepoEnsureICanRemoveReceipt()
        {

            // arrange
            ConnectToDataStore();
            ReceiptModel test_receipt = new ReceiptModel
            {
                ReceiptCapturedId = 1,
                ReceiptType = "pdf",
                Receipt = "testReceipt",
                Retailer = "711",
                PurchaseDate = DateTime.Now,
                S3BuckedId = "3333",
                Purpose = "Remove",
                ReceiptUser = new UserModel
                {
                    UserId = 1,
                    AppEmail = "John.Doe@guthb.com",
                    FirstName = "John",
                    LastName = "Doe"
                }
            };


            // act
            //need to add test that insures the count = 0 after remove
            //ReceiptModel removed_receipt = Repo.RemoveReceipt();

            // assert

        }

    }
}
