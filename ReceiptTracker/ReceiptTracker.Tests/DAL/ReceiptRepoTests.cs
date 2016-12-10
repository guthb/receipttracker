﻿using System;
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
               //not sure how to add users
               new UserModel {
                   //UserId = 1,
                   //ReceiptUser = yeldarba
               },

                new UserModel {
                    //UserId = 1,
                    //ReceiptUser = yeldarbb
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

            // act

            // assert

        }

        [TestMethod]
        public void RepoEnsureUserNameExists()
        {

            // arrange

            // act

            // assert
        }

        [TestMethod]
        public void RepoEnsureUserExistsOfUserName()
        {

            // arrange

            // act

            // assert
        }

        [TestMethod]
        public void RepoEnsureICanCreateaReceipt()
        {

            // arrange

            // act

            // assert
        }

        [TestMethod]
        public void RepoEnsureICanCreateReciptwithData()
        {

            // arrange

            // act

            // assert

        }

    }
}
