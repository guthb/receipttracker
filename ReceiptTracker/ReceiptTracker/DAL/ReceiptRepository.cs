using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReceiptTracker.Models;
using System.Threading.Tasks;

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


        public UserModel FindUserById(int id)
        {
            UserModel found_user = Context.ReceiptUsers.FirstOrDefault(u => u.ReceiptUser.Id.ToString() == id.ToString());
            return found_user;
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

        public UserModel UserNameExistsofUserModel(string v)
        {
           
            return Context.ReceiptUsers.FirstOrDefault(u => u.ReceiptUser.UserName.ToLower() == v.ToLower());
        }

        public UserModel RemoveUser(int userId)
        {
           

            UserModel foundUser = Context.ReceiptUsers.FirstOrDefault(u => u.UserId == userId);
            if (foundUser != null)
            {
                Context.ReceiptUsers.Remove(foundUser);
                Context.SaveChanges();
            }
            return foundUser;
        }

        //GET to return all recipts in database
        public List<ReceiptModel> GetReceipts()
        {
            
            return Context.Receipts.ToList();
        }


        //username is passed in
        public List<ReceiptModel> GetReceiptsForUserName(string user)
        
        {
            var found_receipts = Context.Receipts.Where(x => x.ReceiptUser.ReceiptUser.UserName == user).ToList();

            return found_receipts;
        }

      


        public int AddReceipt(ReceiptModel receiptFromSES)
        {
            Context.Receipts.Add(receiptFromSES);
            return Context.SaveChanges();
        }

        public void AddReceiptPurpose(int receiptId, string purpose)
        {

            ReceiptModel found_receipt = FindReceiptEntered(receiptId);
            if (found_receipt != null)
            {
                found_receipt.Purpose =  purpose ;
                //Context.Receipts.Add(found_receipt);              
                Context.SaveChanges();
                return;
            }

            throw new Exception("Error! Receipt doesn't exist");
        }

        
        public ReceiptModel RemoveReceipt(int receiptId)
        {
            ReceiptModel found_receipt = FindReceiptEntered(receiptId);
            if (found_receipt != null)
            {
                Context.Receipts.Remove(found_receipt);
                Context.SaveChanges();
                return found_receipt;
            }
            else
            {
                throw new Exception("Error! Receipt doesn't exist");
            }
        }

        public ReceiptModel FindReceiptEntered(int test_receipt_id)
        {
            ReceiptModel found_receipt = Context.Receipts.FirstOrDefault(r => r.ReceiptCapturedId == test_receipt_id);
            return found_receipt;
        }

    }
}
