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
            return null;
        }
    }
}