using BusinessLogic.Models;

namespace BusinessLogic.Repositories.DtoConverters
{
    public class TopicConverter: IConverter<Topic, Database.Models.Topic>
    {
        public Topic ConvertToDomainModel(Database.Models.Topic instance)
        {
            throw new System.NotImplementedException();
        }

        public Database.Models.Topic ConvertToDatabaseModel(Topic instance)
        {
            throw new System.NotImplementedException();
        }
    }
}