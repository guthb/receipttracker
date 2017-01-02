using ReceiptTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using System.Web;
//using System.Web.Http;

namespace ReceiptTracker.Controllers

{
    
    [Route("api/putreceipt")]
    public class PutReceiptController : Controller
    {

        ReceiptRepository _repo = new ReceiptRepository();

        // PUT api/<controller>/5
        [HttpPut]
        public void PutReceipt(int id, string value)
        {
            _repo.AddReceiptPurpose(id, value.ToString());

            //return Ok(value);
        }


    }
    
}
