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

            /*var departments = repo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"ID: {department.DepartmentID} Name: {department.Name}");
            }*/

            var productsInChart = new DapperProductRepository(conn);
            //productsInChart.CreateProduct("Carly's MagicBox", 38.99, 8);

            /*var products = productsInChart.GetAllProducts();
            foreach (var item in products)
            {
                Console.WriteLine($"Name: {item.Name} Price: {item.Price} CategoryID: {item.CategoryID}");
            }*/

            Console.WriteLine("What is the product ID you want to update?");
            var prodID = 0;
            int.TryParse(Console.ReadLine(), out prodID);

            Console.WriteLine("What is the new product name?");
            var newName = Console.ReadLine();
            
            productsInChart.UpdateProduct(prodID, newName);

            Console.WriteLine("What is the product ID you want to delete?");
            int.TryParse(Console.ReadLine(), out prodID);
            
            productsInChart.DeleteProduct(prodID);
            
        }
    }
}
