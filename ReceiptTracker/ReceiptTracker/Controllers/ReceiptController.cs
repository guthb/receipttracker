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
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]ReceiptModel value)
        {
            if (_repo.AddReceipt(value) > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Created, value);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }


        // PUT api/<controller>/5
        public void Put(int id, [FromBody]ReceiptModel value)
        {
            _repo.AddReceiptPurpose(id, value.ToString());
            
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}