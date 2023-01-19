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
            const string dtb = "blog";           
            const string connectionString = $"Server=localhost,1433;Database={dtb};User ID=sa;Password='212@@skd77ss*1!';";

            try
            {               
                // TODO: Try to do the connection with server and database 
                using(var connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine($"Connection with Database {dtb} has been successfully!");
                    var checkDataBase = connection.Query($"USE {dtb} ");
                    
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