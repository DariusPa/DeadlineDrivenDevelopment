using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Repositories.DtoConverters;
using BusinessLogic.Repositories.Interfaces;
using Database;
using Microsoft.EntityFrameworkCore;
using DomainLearningDay = BusinessLogic.Models.LearningDay;
using DatabaseLearningDay = Database.Models.LearningDay;


namespace BusinessLogic.Repositories.Implementations
{
    public class LearningDayRepository : IRepository<DomainLearningDay>
    {
        private DatabaseContext _dbContext;
        private IConverter<DomainLearningDay, DatabaseLearningDay> _converter;

        public LearningDayRepository(
            DatabaseContext dbContext,
            IConverter<DomainLearningDay, DatabaseLearningDay> converter)
        {
            _dbContext = dbContext;
            _converter = converter;
        }

        public IList<DomainLearningDay> Get()
        {
            IList<Database.Models.LearningDay> databaseEntries = _dbContext.LearningDays
                .Include(day => day.Employee)
                .Include(day => day.Topic)
                .ToList();

            IList<DomainLearningDay> result = databaseEntries.Select(day => _converter.ConvertToDomainModel(day)).ToList();
            return result;
        }

        public LearningDay GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DomainLearningDay> Add(DomainLearningDay entity)
        {
            DatabaseLearningDay dbEntry = _converter.ConvertToDatabaseModel(entity);
            _dbContext.LearningDays.Add(dbEntry);

            var result = await _dbContext.SaveChangesAsync();
            if (result != 1)
                return null;

            return entity;
        }

        public Task<DomainLearningDay> Update(DomainLearningDay entity)
        {
            throw new System.NotImplementedException();
        }
    }
}