using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ReceiptTracker.DAL;
using ReceiptTracker.Models;
using System.Web.Http;


namespace ReceiptTracker.Controllers
{
    [Route("api/receipt")]
    public class ReceiptController : ApiController
    {

        ReceiptRepository _repo = new ReceiptRepository();
        //private ReceiptRepository _repo;
        //public ReceiptController(ReceiptRepository repo)
        //{
        //    _repo = repo;
        //}


        // GET api/<controller>
        [HttpGet]     
        public IEnumerable<ReceiptModel> Get()
        {
            //return new string[] { "value1", "value2" };
            var receipts = _repo.GetReceipts().OrderByDescending(t => t.PurchaseDate).Take(5);
            return receipts;
        }
        
        // GET api/<controller>/5       
        public string Get(int id)
        {
            return "value";
            //FindReceiptEntered
        }

        // POST api/<controller>
        [HttpPost]       
        public string Post(ReceiptModel newReceiptfromSES)
        {
            ReceiptContext _db = new ReceiptContext();

            if (_repo.AddReceipt( newReceiptfromSES) > 0)
            {
                return HttpStatusCode.OK.ToString();
            }

            return HttpStatusCode.NotModified.ToString();
        }


        // PUT api/<controller>/5
        //[HttpPut]        
        //public HttpResponseMessage Put(int id, string value)
        //{           
        //    _repo.AddReceiptPurpose(id, value.ToString());
        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}