using DomainLearningDay = BusinessLogic.Models.LearningDay;
using DomainEmployee = BusinessLogic.Models.Employee;
using DomainTopic = BusinessLogic.Models.Topic;
using DatabaseLearningDay = Database.Models.LearningDay;
using DatabaseEmployee = Database.Models.Employee;
using DatabaseTopic = Database.Models.Topic;

namespace BusinessLogic.Repositories.DtoConverters
{
    public class LearningDayConverter : IConverter<DomainLearningDay, DatabaseLearningDay>
    {
        private IConverter<DomainEmployee, DatabaseEmployee> _employeeConverter;
        private IConverter<DomainTopic, DatabaseTopic> _topicConverter;

        public LearningDayConverter(
            IConverter<DomainEmployee, DatabaseEmployee> employeeConverter,
            IConverter<DomainTopic, DatabaseTopic> topicConverter)
        {
            _employeeConverter = employeeConverter;
            _topicConverter = topicConverter;
        }

        public DatabaseLearningDay ConvertToDatabaseModel(DomainLearningDay instance)
        {
            DatabaseLearningDay result = new DatabaseLearningDay();
            result.Employee = _employeeConverter.ConvertToDatabaseModel(instance.Employee);
            result.Topic = _topicConverter.ConvertToDatabaseModel(instance.Topic);
            result.Date = instance.Date;
            //TODO: decide on comments
            return result;
        }

        public DomainLearningDay ConvertToDomainModel(DatabaseLearningDay instance)
        {
            DomainLearningDay result = new DomainLearningDay();
            result.Employee = _employeeConverter.ConvertToDomainModel(instance.Employee);
            result.Topic = _topicConverter.ConvertToDomainModel(instance.Topic);
            result.Date = instance.Date;
            // todo: decide on comments
            return result;
        }
    }
}