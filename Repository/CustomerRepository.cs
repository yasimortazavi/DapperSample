using Dapper;
using System.Data.Common;
using System.Data.SqlClient;

namespace Repository
{
    public interface ICustomerRepository
    {
        int Add(CuustomerDto customer);
    
    }
    public class CustomerRepository: ICustomerRepository
    {
        private readonly string  ConnectionString = @"server = DESKTOP-4PP4QV0; Initial Catalog = DapperDb; integrated security =True;"; 

        public int Add(CuustomerDto customer)
        {
            string sql = "INSERT INTO Customers (Name, LastName) Values (@Name, @LastName)";
            var connection = new SqlConnection (ConnectionString);
            var Result = connection.Execute(sql, new { Name = customer.Name, LastName = customer.LastName});
            return Result;
        }
    }
    public class CuustomerDto
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

    }
}
