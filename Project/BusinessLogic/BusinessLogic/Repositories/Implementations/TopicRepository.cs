using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Repositories.DtoConverters;
using BusinessLogic.Repositories.Interfaces;
using Database;
using Microsoft.EntityFrameworkCore;
using DomainTopic = BusinessLogic.Models.Topic;
using DatabaseTopic = Database.Models.Topic;


namespace BusinessLogic.Repositories.Implementations
{
    public class TopicRepository : IRepository<DomainTopic>
    {
        private DatabaseContext _dbContext;
        private IConverter<DomainTopic, DatabaseTopic> _converter;

        public TopicRepository(
            DatabaseContext dbContext,
            IConverter<DomainTopic, DatabaseTopic> converter)
        {
            _dbContext = dbContext;
            _converter = converter;
        }

        public IList<DomainTopic> Get()
        {
            IList<DatabaseTopic> databaseEntries = _dbContext.Topics
                .Include(topic => topic.Title)
                .Include(topic => topic.Subtopics)
                .Include(topic => topic.ExtraInformation)
                .ToList();

            IList<DomainTopic> result = databaseEntries.Select(topic => _converter.ConvertToDomainModel(topic)).ToList();
            return result;
        }

        public Topic GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DomainTopic> Add(DomainTopic entity)
        {
            DatabaseTopic dbEntry = _converter.ConvertToDatabaseModel(entity);
            _dbContext.Topics.Add(dbEntry);

            var result = await _dbContext.SaveChangesAsync();
            if (result != 1)
                return null;

            return entity;
        }

        public Task<DomainTopic> Update(DomainTopic entity)
        {
            throw new System.NotImplementedException();
        }
    }
}