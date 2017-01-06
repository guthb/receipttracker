using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ReceiptTracker.DAL;
using ReceiptTracker.Models;
using System.Web.Http;
using Microsoft.AspNet.Identity;


namespace ReceiptTracker.Controllers
{
    
    [Route("api/receipt")]
    public class ReceiptController : ApiController
    {

        ReceiptRepository _repo = new ReceiptRepository();
 

        // GET api/<controller>
        [HttpGet]
        [Route("api/receipt/user/{user}")]
        
        //public string Get(string user)
        public IEnumerable<ReceiptModel> Get(string user)
        {
            IEnumerable<ReceiptModel> receipts = null;
            try
            {
                user = User.Identity.GetUserName();

                //return new string[] { "value1", "value2" };
                //var receipts = _repo.GetReceipts().OrderByDescending(t => t.PurchaseDate).Take(10);
                receipts = _repo.GetReceiptsForUserName(user);
            } catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
            return receipts;

        }
        
        // GET api/<controller>/5       
        //public string Get(int id)
        //{
        //    return "value";
        //    //FindReceiptEntered
        //}

        // POST api/<controller>
        //[HttpPost]       
        public string Post(ReceiptModel newReceiptfromSES)
        {
            ReceiptContext _db = new ReceiptContext();
            try
            {
                if (_repo.AddReceipt(newReceiptfromSES) > 0)
                {
                    return HttpStatusCode.OK.ToString();
                }
            } catch (Exception exp)
            {
                Console.Write("Post controller", exp.Message);
            }
            return HttpStatusCode.NotModified.ToString();
        }


        // PUT api/<controller>/5
        [Authorize]        
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            _repo.AddReceiptPurpose(id, value.ToString());
            return new HttpResponseMessage(HttpStatusCode.OK); //200
        }


        // DELETE api/<controller>/5
        
        public HttpResponseMessage Delete(int id)
        {
            _repo.RemoveReceipt(id);

            return new HttpResponseMessage(HttpStatusCode.NoContent); //204
        }
    }
}