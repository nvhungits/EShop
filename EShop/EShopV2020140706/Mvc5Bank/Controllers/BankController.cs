using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mvc5Bank.Controllers
{
    public class BankController : ApiController
    {
        Mvc5Bank db = new Mvc5Bank();
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
        public void Put(String id, Account account)
        {
            var nn = db.Accounts.Find(id);
            var cust = db.Accounts.Find(account.Id);
            nn.Balance += account.Balance;
            cust.Balance -= account.Balance;
            
            db.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}