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
            //throw new NotImplementedException();
            return Context.ReceiptUsers.FirstOrDefault(u => u.ReceiptUser.UserName.ToLower() == v.ToLower());
        }

        public UserModel RemoveUser(int userId)
        {
            //throw new NotImplementedException();

            UserModel foundUser = Context.ReceiptUsers.FirstOrDefault(u => u.UserId == userId);
            if (foundUser != null)
            {
                Context.ReceiptUsers.Remove(foundUser);
                Context.SaveChanges();
            }
            return foundUser;
        }

        public List<ReceiptModel> GetReceipts()
        {
            
            return Context.Receipts.ToList();
        }

        public int AddReceipt(ReceiptModel receiptFromSES)
        {
            Context.Receipts.Add(receiptFromSES);
            return Context.SaveChanges();
        }



        public void AddReceiptPurpose(int receiptId, string purpose)
        {

            ReceiptModel found_receipt = FindReceiptEntered(receiptId.ToString());
            if (found_receipt != null)
            {
                found_receipt.Purpose =  purpose ;
                Context.Receipts.Add(found_receipt);
                Context.SaveChanges();
                return;
            }

            //ReceiptModel _receipt_purpose = new ReceiptModel {Purpose = purpose };
            //Context.Receipts.Add(_receipt_purpose);
            //Context.SaveChanges();

            throw new Exception("Error! Receipt doesn't exist");
        }

        
        public ReceiptModel RemoveReceipt(int receiptId)
        {
            ReceiptModel found_receipt = FindReceiptEntered(receiptId.ToString());
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

        public ReceiptModel FindReceiptEntered(string test_receipt)
        {
            ReceiptModel found_receipt = Context.Receipts.FirstOrDefault(r => r.ReceiptCapturedId.ToString() == test_receipt.ToString());
            return found_receipt;
        }

    }
}
