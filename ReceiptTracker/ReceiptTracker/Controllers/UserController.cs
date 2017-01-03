using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ReceiptTracker.DAL;
using System.Web.Http;

namespace ReceiptTracker.Controllers
{
    [Route("api/user")]
    public class UserController : ApiController
    {

        ReceiptRepository _repo = new ReceiptRepository();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        //public void Delete(int id)
        public IHttpActionResult Delete(int id)
        {
            _repo.RemoveUser(id);
            return Json("User Removed Succefully!");
        }
    }
}