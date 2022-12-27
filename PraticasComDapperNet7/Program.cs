using System;
using Microsoft.Data.SqlClient;
using Dapper;
using PraticasComDapper.PraticascomDapperNet7;

namespace PraticasComDapper.PraticasComDapperNet7
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region trabalhando com banco usando Dapper
            
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password='212@@skd77ss*1!';";
            
            try
            {              
                using (var connection = new SqlConnection(connectionString))
                {
                    ListCategories(connection);
                    //CreateCategory(connection);
                   //UpdateCategory(connection);   
                    //DeleteCategory(connection);           
                }
            }
            catch (System.Exception e)
            {
               Console.WriteLine("Ops... ocorreu algum erro -->> \n" + e);
            }          
            
            #endregion
        }
        #region conexao como banco

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [ID], [TITLE], [ORDER] FROM [CATEGORY]");
            foreach (var items in categories)
            {
               System.Console.WriteLine($"{items.Id} - {items.Title}");
            }
        }
        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Notar.io";
            category.Url = "Backend";
            category.Description = "like,share,subscribe";
            category.Order = 8;
            category.Summary = "ina_Dev.io";
            category.Featured = false;

            var insertQuery = @"INSERT INTO [CATEGORY] VALUES(@Id,@Title,@Url,@Summary,@Order,@Description,@Featured)";
            var insertRows = connection.Execute(insertQuery, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });            
            System.Console.WriteLine($"{insertRows} Registros Inseridos");

           
        }
        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = @"UPDATE [CATEGORY] 
            SET [Title]=@title, [Url]=@url,[Summary]=@summary, [Order]=@order,
                [Description]=@description, [Featured]=@featured WHERE [Id]= @id ";
            var updateRows = connection.Execute(updateQuery, new
            {
                Id = ("a6519bfd-2f21-49ab-bc14-a32252e69f33"),
                Title =("Security"),
                Url = ("SecOps"),
                Summary = ("Aprenda a proteger seus Docker Files"),
                Order = 9,
                Description = "Aprenda SecOps",
                Featured = true



            });  
            System.Console.WriteLine($"{updateRows} registos atualizados");
        }
        static void DeleteCategory(SqlConnection connection)
        {
            var deleteQuery = @" DELETE FROM [CATEGORY] WHERE [Id]= @id";
            var deleteRows = connection.Execute(deleteQuery, new
            {
                //Id = ("52100872-02b4-4f17-9654-bffd4e8bf9c9"),
                //Id = ("bd9eb6e2-7cad-4eae-8e4c-d75bdbfd1498")
                Id = ("1dfa7731-b21d-423e-b83a-e1b07058f7bf")
            }
            );
            System.Console.WriteLine($"{deleteRows} linha removida");
        }
        
        #endregion   
    }
}