namespace BusinessLogic.Repositories.DtoConverters
{
    public interface IConverter<TDomainModel, TDatabaseModel>
    {
        TDomainModel ConvertToDomainModel(TDatabaseModel instance);
        TDatabaseModel ConvertToDatabaseModel(TDomainModel instance);
    }
}