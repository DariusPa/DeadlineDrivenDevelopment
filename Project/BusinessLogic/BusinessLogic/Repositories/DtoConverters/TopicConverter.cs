using BusinessLogic.Models;
using DomainExtraInformation = BusinessLogic.Models.ExtraInformation;
using DatabaseExtraInformation = Database.Models.ExtraInformation;
using DomainTopic = BusinessLogic.Models.Topic;
using DatabaseTopic = Database.Models.Topic;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Repositories.DtoConverters
{
    public class TopicConverter: IConverter<DomainTopic, DatabaseTopic>
    {
        private IConverter<DomainExtraInformation, DatabaseExtraInformation> _extraInformationConverter;

        public TopicConverter(IConverter<DomainExtraInformation, DatabaseExtraInformation> extraInformationConverter)
        {
            _extraInformationConverter = extraInformationConverter;
        }
        public DomainTopic ConvertToDomainModel(DatabaseTopic instance)
        {
            DomainTopic result = new DomainTopic();
            result.Title = instance.Title;
            result.ExtraInformation = new List<DomainExtraInformation>();
            result.Subtopics = new List<DomainTopic>();
            result.ExtraInformation = instance.ExtraInformation
                .Select(info => _extraInformationConverter.ConvertToDomainModel(info)).ToList();
            result.Subtopics = instance.Subtopics
                .Select(subtopic => ConvertToDomainModel(subtopic)).ToList();
            return result;
        }

        public DatabaseTopic ConvertToDatabaseModel(DomainTopic instance)
        {
            DatabaseTopic result = new DatabaseTopic();
            result.Title = instance.Title;
            result.ExtraInformation = new List<DatabaseExtraInformation>();
            result.Subtopics = new List<DatabaseTopic>();
            result.ExtraInformation = instance.ExtraInformation
                .Select(info => _extraInformationConverter.ConvertToDatabaseModel(info)).ToList();
            result.Subtopics = instance.Subtopics
                .Select(subtopic => ConvertToDatabaseModel(subtopic)).ToList();
            return result;
        }
    }
}