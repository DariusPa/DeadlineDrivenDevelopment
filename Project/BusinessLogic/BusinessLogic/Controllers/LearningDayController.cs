using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [Route("api/learningday/")]
    public class LearningDayController
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<int>> Get()
        {
            // example of db query
            var ids = _dbContext.TestModels.Select(model => model.Id).ToList();
            return ids;
        }
    }
}