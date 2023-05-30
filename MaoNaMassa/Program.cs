using Dapper;
using Microsoft.Data.SqlClient;
using PraticasComDapper.MaoNaMassa.Models;
using PraticasComDapper.MaoNaMassa.Repositories;

namespace PraticasComDapper.MaoNaMassa
{
    public class Program 
    {
        public static void Main(string[] args)
        {   const string dbName = "blog";         
            const string connectionString = $"Server=localhost,1433;Database={dbName};User ID=sa;Password='212@@skd77ss*1!'";
            
            try
            { 
                using var connection = new SqlConnection(connectionString);
                Console.WriteLine($"Connection with Database {dbName} has been successfully!");  
                //User user = new User();
                ReadTable(connection); 
               //ReadAllTable(connection);
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Connection failed, error:"+e);    
            }
        }
        private static void ReadTable(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get(1);
            Console.WriteLine($"{users.Id}");
            Console.WriteLine($"{users.Name}");
            Console.WriteLine($"{users.Email}");                      
        }        
        private static void InsertRow(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            //var User user = new User();
            var users = repository.Create;                   
                // user.Name = "Inacio Oliveira",
                // user.Email = "inacio.oliveira@email.com",
                // user.PasswordHash = "123456",
                // user.Bio = "Navegante nas aguas do Dotnet",
                // user.Image = "IMAGE",
                // user.Slug = "https://inacio\Sobre Mim"                
        }        
    }
}





