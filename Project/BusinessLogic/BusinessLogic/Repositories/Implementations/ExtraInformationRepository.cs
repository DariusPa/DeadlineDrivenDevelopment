using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Repositories.DtoConverters;
using BusinessLogic.Repositories.Interfaces;
using Database;
using Microsoft.EntityFrameworkCore;
using DomainExtraInformation = BusinessLogic.Models.ExtraInformation;
using DatabaseExtraInformation = Database.Models.ExtraInformation;


namespace BusinessLogic.Repositories.Implementations
{
    public class ExtraInformationRepository : IRepository<DomainExtraInformation>
    {
        private DatabaseContext _dbContext;
        private IConverter<DomainExtraInformation, DatabaseExtraInformation> _converter;

        public ExtraInformationRepository(
            DatabaseContext dbContext,
            IConverter<DomainExtraInformation, DatabaseExtraInformation> converter)
        {
            _dbContext = dbContext;
            _converter = converter;
        }

        public IList<DomainExtraInformation> Get()
        {
            IList<DatabaseExtraInformation> databaseEntries = _dbContext.ExtraInformation
                .Include(info => info.Date)
                .Include(info => info.Content)
                .Include(info => info.Links)
                .ToList();

            IList<DomainExtraInformation> result = databaseEntries.Select(info => _converter.ConvertToDomainModel(info)).ToList();
            return result;
        }

        public ExtraInformation GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DomainExtraInformation> Add(DomainExtraInformation entity)
        {
            DatabaseExtraInformation dbEntry = _converter.ConvertToDatabaseModel(entity);
            _dbContext.ExtraInformation.Add(dbEntry);

            var result = await _dbContext.SaveChangesAsync();
            if (result != 1)
                return null;

            return entity;
        }

        public Task<DomainExtraInformation> Update(DomainExtraInformation entity)
        {
            throw new System.NotImplementedException();
        }
    }
}