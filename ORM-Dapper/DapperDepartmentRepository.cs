using System.Data;
namespace ORM_Dapper;
using Dapper;

public class DapperDepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;
    public DapperDepartmentRepository(IDbConnection connection)//constructor: Here, whenever I create a new instance of the DapperDepartmentRepository, I will pass in the connection string as a parameter and set that connection string in my private readonly variable _connection.
    {
        _connection = connection;
    }
    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM Departments;").ToList();
    }

    public void InsertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@newdepartmentName);", new {newDepartmentName});
    }
}