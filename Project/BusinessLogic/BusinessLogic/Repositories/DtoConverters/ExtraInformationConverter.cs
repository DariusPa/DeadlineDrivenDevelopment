using BusinessLogic.Models;
using DomainExtraInformation = BusinessLogic.Models.ExtraInformation;
using DatabaseExtraInformation = Database.Models.ExtraInformation;
using DomainTopic = BusinessLogic.Models.Topic;
using DatabaseTopic = Database.Models.Topic;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Repositories.DtoConverters
{
    public class ExtraInformationConverter: IConverter<DomainExtraInformation, DatabaseExtraInformation>
    {
    
        public DomainExtraInformation ConvertToDomainModel(DatabaseExtraInformation instance)
        {
            DomainExtraInformation result = new ExtraInformation();
            result.Date = instance.Date;
            result.Content = instance.Content;
            result.Links = instance.Links;
            return result;
        }

        public DatabaseExtraInformation ConvertToDatabaseModel(DomainExtraInformation instance)
        {
            DatabaseExtraInformation result = new DatabaseExtraInformation();
            result.Date = instance.Date;
            result.Content = instance.Content;
            result.Links = instance.Links.ToList();
            return result;
        }
    }
}