using System.Collections.Generic;
using BusinessLogic.Models;
using BusinessLogic.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [Route("api/topics/")]
    public class TopicController
    {
        private IRepository<Topic> _repository;

        public TopicController(IRepository<Topic> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Topic> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        public Topic Post([FromBody] Topic topic)
        {
            // TODO
            return null;
        }
    }
}