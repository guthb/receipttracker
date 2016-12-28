﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ReceiptTracker.DAL;
using ReceiptTracker.Models;
using System.Web.Http;


namespace ReceiptTracker.Controllers.api
{
    [Route("api/[controller]")]
    public class ReceiptController : ApiController
    {

        //ReceiptRepository Repo = new ReceiptRepository();
        private ReceiptRepository _repo;
        public ReceiptController(ReceiptRepository repo)
        {
            _repo = repo;
        }


        // GET api/<controller>
        //[HttpGet]
        public IEnumerable<ReceiptModel> Get()
        {
            //return new string[] { "value1", "value2" };
            var receipts = _repo.GetReceipts().OrderByDescending(t => t.PurchaseDate).Take(50);
            return receipts;
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
        public void Delete(int id)
        {
        }
    }
}