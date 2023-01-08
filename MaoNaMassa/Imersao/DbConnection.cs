using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using PraticasComDapper.MaoNaMassa.Models;

namespace PraticasComDapper.MaoNaMassa.Imersao
{
    public class DbConnection 
    {
        private int Connection { get; set; }
        public  DbConnection(){}
        public DbConnection(int connection)
        {
            this.Connection = connection;
        }
        public  void connection()
        {
            const string database = "blog";
            const string host = "localhost";
            const string port = "1433";
            const string userName = "sa";
            const string password = "212@@skd77ss*1!";            
            const string connectionString = $"Server={host},{port};Database={database};User ID={userName};Password='{password}';";
            
            try
            {               
                // TODO: Try to do the connection with server and database 
                using(var connection = new SqlConnection(connectionString))
                {                     
                    var checkDataBase = connection.Query($"USE {database} ");
                    Console.WriteLine($"Connection with Database {database} was successfully!");
                }             
            }
            catch (System.Exception e)
            {
                 // TODO: Error Response                 
                 Console.WriteLine("Connection failed, error:"+e);
                
            }
        }
    }
}