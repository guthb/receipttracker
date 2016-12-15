﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReceiptTracker.Models;

namespace ReceiptTracker.DAL
{
    public class ReceiptRepository
    {
        public ReceiptContext Context { get; set; }

        public ReceiptRepository()
        {
            Context = new ReceiptContext();
        }

        public ReceiptRepository(ReceiptContext _context)   //only used when we want to connect to a real database
        {
            Context = _context;
        }

        public List<string> GetUserNames()
        {
            //throw new NotImplementedException();
            return Context.ReceiptUsers.Select(u => u.ReceiptUser.UserName.ToLower()).ToList();
        }

        public bool UserNameExists(string v)
        {
            //throw new NotImplementedException();
             UserModel foundUser = Context.ReceiptUsers.FirstOrDefault(u => u.ReceiptUser.UserName.ToLower() == v.ToLower());
            if (foundUser != null)
            {
                return true;
            }
            return false;
        }
    }
}