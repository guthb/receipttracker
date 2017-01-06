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
    
    [Route("api/update/")]
    //public class UpdateController : Controller  //(mvc)
    public class UpdateController : ApiController
    {

        ReceiptRepository _repo = new ReceiptRepository();
        
        // PUT api/<controller>/5
        [HttpPut]
        //public void PutReceipt(int id, string value) //(mvc)        
        //public string put([FromUri] int id, string value)
        //public IHttpActionResult Put(int id, string value)
        public IHttpActionResult Put(Purpose p)
        {
            _repo.AddReceiptPurpose(p.id, p.purpose);

            return Json("Purpose added successfully!");
            //return 
        }


        // DELETE api/<controller>/5
        [HttpDelete]
        [AcceptVerbs("delete")]
        //public HttpResponseMessage Delete(int id)
        public IHttpActionResult Delete(int id)
        {
            _repo.RemoveReceipt(id);

            //return new HttpResponseMessage(HttpStatusCode.NoContent); //204
            return Json("receipt removed");
        }




    }
    
}
