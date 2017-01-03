using ReceiptTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Mvc;
using System.Web;
using System.Web.Http;

namespace ReceiptTracker.Controllers

{

    public class Purpose
    {
        public int id { get; set; }
        public string purpose { get; set; }
    }
    
    [Route("api/update/{id, value}")]
    //public class UpdateController : Controller  //(mvc)
    public class UpdateController : ApiController
    {

        ReceiptRepository _repo = new ReceiptRepository();
        
        // PUT api/<controller>/5
        [HttpPut]
        //public void PutReceipt(int id, string value) //(mvc)
        public IHttpActionResult put(int id, string value)
        //public string put([FromUri] int id, string value)
        {
            _repo.AddReceiptPurpose(id, value.ToString());

            return Json("Purpose added successfully!");
            //return new HttpResponseMessage(HttpStatusCode.OK).ToString();
        }


    }
    
}
