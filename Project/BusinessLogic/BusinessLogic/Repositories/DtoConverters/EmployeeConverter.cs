using BusinessLogic.Models;

namespace BusinessLogic.Repositories.DtoConverters
{
    public class EmployeeConverter : IConverter<Employee, Database.Models.Employee>
    {
        public Employee ConvertToDomainModel(Database.Models.Employee instance)
        {
            throw new System.NotImplementedException();
        }

        public Database.Models.Employee ConvertToDatabaseModel(Employee instance)
        {
            throw new System.NotImplementedException();
        }
    }
}