using System;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using PraticasComDapper.PraticasComDappernet7;

namespace PraticasComDapper.PraticasComDapperNet7
{
    class Program : ComandosSql
    {
        static void Main(string[] args)
        {            
           ComandosSql call = new ComandosSql();
            
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password='212@@skd77ss*1!';";
            
            try
            {              
                using (var connection = new SqlConnection(connectionString))
                {
                    do
                    {
                         Console.WriteLine("\nwhat do you want to realize?");
                         Console.WriteLine("\n1- List categories\n2- Create category\n3- Update Category");
                         Console.WriteLine("4- Delete Category\n5- Delete Procedure\n6- Do Like");
                         Console.WriteLine("Wich Query do You want to do:");
                         var num = int.Parse(Console.ReadLine());
                         switch (num)
                         {
                             case 1:
                                 listCategories(connection);
                                 break;
                             case 2:
                                 createCategory(connection);
                                 break;
                             case 3:
                                 updateCategory(connection);
                                 break;
                             case 4:
                                 deleteCategory(connection);
                                 break;
                             case 5:
                                 deleteProcedure(connection);
                                 break;
                             case 6:
                                 doLike(connection);
                                 break;
                             default:
                                 Console.WriteLine("It Ends Here... tku");
                                 break;
                        }     
                    } 
                    while (true);
                }
            }
            catch (System.Exception e)
            {
               Console.WriteLine("Ops...An Error Has Occurred-->> \n" + e);
            }          
            
           
        }

   

       
        
    }
}