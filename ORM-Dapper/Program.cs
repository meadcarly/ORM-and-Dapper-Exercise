using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
namespace ORM_Dapper

{
    public class Program
    {
        static void Main(string[] args)
        {
//^^^^MUST HAVE USING DIRECTIVES^^^^

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            
            var repo = new DapperDepartmentRepository(conn);
            
            //repo.InsertDepartment("Carly's Department");

            var departments = repo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"ID: {department.DepartmentID} Name: {department.Name}");
            }
        }
    }
}
