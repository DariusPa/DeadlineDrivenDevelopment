using System.Collections.Generic;
using BusinessLogic.Models;
using BusinessLogic.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Controllers
{
    [Route("api/extrainformation/")]
    public class ExtraInformationController
    {
        private IRepository<ExtraInformation> _repository;

        public ExtraInformationController(IRepository<ExtraInformation> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<ExtraInformation> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        public Topic Post([FromBody] ExtraInformation extraInformation)
        {
            // TODO
            return null;
        }
    }
}