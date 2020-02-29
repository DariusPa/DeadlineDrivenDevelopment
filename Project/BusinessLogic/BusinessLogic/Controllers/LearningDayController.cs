using System.Collections.Generic;
using BusinessLogic.Models;
using BusinessLogic.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [Route("api/learningday/")]
    public class LearningDayController
    {
        private IRepository<LearningDay> _repository;

        public LearningDayController(IRepository<LearningDay> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<LearningDay> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        public LearningDay Post([FromBody] LearningDay learningDay)
        {
            // TODO
            return null;
        }
    }
}