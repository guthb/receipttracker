using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReceiptTracker.DAL;

namespace ReceiptTracker.Controllers
{

    public class DeleteReceipt
    {
        public int id { get; set; }
    }

    [Route("api/delete")]
    public class DeleteController : ApiController
    {
        ReceiptRepository _repo = new ReceiptRepository();

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage Delete( DeleteReceipt id )
        {
            _repo.RemoveReceipt(id.id);

            return new HttpResponseMessage(HttpStatusCode.NoContent); //204
        }


    }
}
