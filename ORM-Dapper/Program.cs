using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            // var departmentRepos = new DapperDepartmentRepository(conn);
            //
            //
            //
            // var departments = departmentRopos.GetAllDepartments();
            //
            // foreach (var department in departments)
            // {
            //     Console.WriteLine(department.DepartmentID);
            //     Console.WriteLine(department.Name);
            //     Console.WriteLine();
            //
            //     
            // }
            var repo = new DapperProductRepository(conn);
           // repo.CreateProduct("Test Product", 20.00,1);
           var products = repo.GetAllProducts();

            foreach (var prod in  products)
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name}");
            }

        }
    }
}
