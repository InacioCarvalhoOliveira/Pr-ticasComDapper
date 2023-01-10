using Microsoft.Data.SqlClient;
using Dapper;
using PraticasComDapper.MaoNaMassa.Models;
using Dapper.Contrib.Extensions;

namespace PraticasComDapper.MaoNaMassa.Imersao
{
    public class DbConnection : User
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
                    Console.WriteLine($"Connection with Database {database} has been successfully!");
                    var checkDataBase = connection.Query($"USE {database} ");
                    
                    #region ReadQuery                   
                        //    var readuser = connection.Get<User>(1);
                        //    Console.WriteLine($"{readuser}");                        
                    #endregion
                    #region CreateQuery
                        //    var createuser = new User(){
                        //         Name = "Elis Regina",
                        //         PasswordHash = "HASH",
                        //         Email = "elis@regina.com.br",
                        //         Bio = "Como Nossos Pais",
                        //         Image = "https:\\",
                        //         Slug = "elis-regina",
                        //     };
                        //     connection.Insert<User>(createuser);                         
                    #endregion  
                    #region UpdateQuery                        
                        //     var updateUser = new User(){
                                
                        //         Id = 6,
                        //         Name = "Elis Regina",
                        //         PasswordHash = "HASH",
                        //         Email = "elis@regina.com.br",
                        //         Bio = "Falso Brilhante",
                        //         Image = $"https:",
                        //         Slug = "elis-regina",
                        //     };
                        //     connection.Update<User>(updateUser);
                    #endregion
                    #region DeleteQuery
                        //     var deleteUser = new User(){
                                
                        //         Id = 6,   
                        //     };
                        //     connection.Delete<User>(deleteUser);                    
                    #endregion

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