using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [Route("api/values/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DatabaseContext _dbContext;

        // example of context injection
        public ValuesController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<int>> Get()
        {
            // example of db query
            var ids = _dbContext.TestModels.Select(model => model.Id).ToList();
            return ids;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}